LOCALHOST

In VSCode menu "Run and Debug"
	Debug "Attach to .NET Functions"
	Once it starts, then select "SWA: Run..." and Debug

to build for prod and see if there are any linting error before deploying, run the following:
npm run build

FINETUNING

 * Go to Google Sheets, save file as Excel
 * Go to Admin page, upload Excel file
 * For all 8 textareas, copy and paste into Notepad++ and save as <completionType>.jsonl
 * export OPENAI_API_KEY="get the key from the OpenAI portal"
 * Run this tool as a sanity check on data formatting
 ** openai tools fine_tunes.prepare_data -f "sg_finetune\orphanSummary.jsonl"
 * To kick off a finetune job:
 ** SUMMARY: openai api fine_tunes.create -t "sg_finetune\orphanSummary.jsonl" -m davinci --n_epochs 3 --learning_rate_multiplier 0.03
 ** FULL: openai api fine_tunes.create -t "sg_finetune\orphanFull.jsonl" -m davinci --n_epochs 3 --learning_rate_multiplier 0.035
 *** "Using Lower learning rate and only 1-2 epochs tends to work better for these use cases"
 *** "Aim for at least ~500 examples"
 *** default n_epochs=4, default learning_rate_multiplier=0.05
 *** experiment with values in the range 0.02 to 0.2 to see what produces the best results
 *** you'll get a response like: Created fine-tune: ft-aySH26zbI46aMKvL5OxWQJ4h
 *** if disconnected, run: openai api fine_tunes.follow -i ft-aySH26zbI46aMKvL5OxWQJ4h
 * in the OpenAI portal, you'll see under "Fine-tune training" a model name like "davinci:ft-personal-2022-01-07-04-27-42" Plug this value into the dictionary in Generate.cs
 * When calling via Postman at about 10 min after the finetune job reported success, I initially got an HTTP 429 response (Too Many Requests)
 ** After 15 min, the request succeeded. So, the C# needs to check for HTTP 429, and implement a message back to the user to wait a bit and retry.
* “A Curie fine-tuned on 100 examples may have similar results to a Babbage fine-tuned on 2,000 examples. The larger models can do remarkable things with very little data.” - https://bdtechtalks.com/2021/11/29/gpt-3-application-development-tips/
 * The documentation also states for conditional generation: "aim for at least ~500 examples" and "Using Lower learning rate and only 1-2 epochs tends to work better for these use cases"
 * My prompts all start with "Here is a summary of an award winning story: " When fine tuning, is that style of prompt still useful to start every row of example data? ANSWER: with a small number of examples, the repeated prompt language is useful, but as I get closer to 100 examples, it may no longer be necessary

IDEAS:

 * Hype/marketing - every time someone completes a full story, update a global NoSQL container counter. This metric is more valuable than anything from Google Analytics for measuring success
 * After GPT-3 fills a page with an idea, now encourage the author to make tweaks like a co-author brainstorm. Human needs to be part of the process like an editor forging the ideas into something even better. AI can still assist with this process, ex: "Prompt: Given the previous sequence of events, we see the following symbolism is present. " Encourage the author to layer in more theme/symbolism/nuance.
 * We can use DaVinci (highest quality) to generate yet more unique training samples for later finetuning. Human curated from examples to pick out "good" stories.
 * Larger models require less data for fine-tuning. https://thenextweb.com/news/building-apps-gpt-3-what-devs-need-know-cost-performance-syndication
 ** “For many tasks, you can think of increasing base model size as a way to reduce how much data you’ll need to fine-tune a quality model,” Shumer said. “A Curie fine-tuned on 100 examples may have similar results to a Babbage fine-tuned on 2,000 examples. The larger models can do remarkable things with very little data.”
 ** some tasks (i.e., multi-step generation) are too complex for a vanilla model, even Davinci, to complete with high accuracy,” Shumer said. “In cases like this, you have two options: 1) create a prompt chain that feeds outputs from one prompt into another prompt, or 2) fine-tune a model. I typically first try to create a prompt chain, and if that doesn’t work, I then move to fine-tuning.”
 * Big picture direction of generative media: https://arr.am/2020/09/15/the-generative-age/
 * at each completion, we can use the GPT-3 Intents model for additional stylistic editing, like "Prompt: <previous completion>. Write a more exciting and dramatic version of these events." OR "make this sequence of events more romantic/scifi/magical/humorous"


TODO:
 * (ongoing) continue adding to finetuning dataset
 * add text area input length limit to avoid malicious long inputs from using up all my prompt tokens
 * Review keywords for all Log Line objects, maybe cut back on some examples to save on GPT-3 tokens
 * spend time in playground refining prompts. Look for list of prompts online for inspiration.
 * apply prompt lessons to "full" prompt, then finetune orphanFull to look for problems in practice
 * Set up KeyVault integration for OpenAI key and db connection strings, log GPT responses to a db. This db can be used to manually review and use to further finetune the model to improve future output. Bool cols for IsGenerated and IsGoodForFinetuning (default false for generated text, once I manually review I can choose to flip it)

PROMPT DESIGN

 * GPT-3 prompt examples: https://beta.openai.com/examples
 Summarize for a 2nd grader
 ** Micro horror story creator
 ** Essay outline
 * Ensure that the prompt + completion doesn't exceed 2048 tokens, including the separator
 * OpenAI advises not to use the format of Param1=Value1. Instead convert it to natural short sentences like Param1 is a Value1. Param2 is a Value2.
 * It is important that every log line input param have some presence in the completion log line summary text to demonstrate a connection
 * https://bmk.sh/2019/10/27/The-Difficulties-of-Text-Generation-with-Autoregressive-Language-Models/
 ** "One major problem with maximum-likelihood training of autoregressive models is exposure bias (Ranzato et al., 2015). Autoregressive models are only trained and evaluated on samples drawn from the target language distribution, but at evaluation time are fed samples that are themselves generated by the model. This error compounds extremely quickly and it has been observed, though admittedly anecdotally, that GPT-2 exhibits a sharp drop-off in quality after a certain number of steps."
 ** IDEA: does this mean I shouldn't directly feed completions back into the next prompt? Do some light manipulation first? Ideally, the author will introduce their own entropy into the system to modify each output before requesting the next completion
 * https://www.gwern.net/GPT-3#quality
 ** For fiction, I treat it as a curation problem: how many samples do I have to read to get one worth showing off? [...] A Markov chain text generator trained on a small corpus represents a huge leap over randomness: instead of having to generate countless quadrillions of samples, one might only have to generate millions of samples to get a few coherent pages; this can be improved to hundreds or tens of thousands by increasing the depth of the n of its n-grams. […] But for GPT-3, once the prompt is dialed in, the ratio appears to have dropped to closer to 1:5—maybe even as low as 1:3!
 * The OpenAI example for micro-horror: https://beta.openai.com/examples/default-micro-horror has hyper params Temperature=0.5 and Frequency Penalty=0.5


PROMPT IDEAS

 * from the forums: "keep it simple, less words is better, and give it a very good thorough example - just one really good one should do for what you want to to"
 * which leads me back to experimenting with the prompts in Playground before I attempt any finetuning

-------- (FROM OPENAI EXAMPLES)
Topic: Breakfast
Two-Sentence Horror Story: He always stops crying when I pour the milk on his cereal. I just have to remember not to let him see his face on the carton.
###
Topic: Wind
Two-Sentence Horror Story:
--------
 * The above is a small version of what I'm after. Perhaps I should consider the style "Genre: scifi" instead of "The genre is Scifi"?
--------

Here’s a short story by Terry Pratchett.

Barry
By Terry Pratchett

Death looked at the man and said ‘HELLO.’
----------
Here is an award winning short story:

They Come From The Earth
By John Vickersonik
----------------
Here is an award winning short story:
----------------
Here is a short story:

 * quality of output degrades when you remove "award winning"

---------------

The following is an author's summary of a story involving [log line description]. The author's summary is concise and only covers the very beginning of the story.

---------------

[summary here]

The following is how a skilled author would expand the above summary into more detailed story beats:

--------------

Here's a three-sentence summary of the plot so far:

--------------

Write a novel with the following description
Genre: Epic science fiction space opera
Style: Mythic, like Frank Herbert's Dune or Tolkien's Silmarillion
Premise: An object, the Obelisk, has been found in deep space on a route between the Milky Way and Andromeda galaxies. The object is a giant diamond in shape, but of unknown material and origin. This story follows several perspectives as they wrangle with the truth of the Obelisk. Religious orders claim it, as to scientific and governmental agencies.

The story so far: Beginning

--------------
 * I like the hint words in the prompt above of "Premise" and "The story so far: Beginning"
--------------
Continue writing a novel based on the summary and last chunk.

Example 1:
Summary: <<SUMMARY>>
Last chunk: <<NOVEL>>
Continuation: <<IDEAL COMPLETION>>

Example 2:
Summary: <<SUMMARY>>
Last chunk: <<NOVEL>>
Continuation: <<IDEAL COMPLETION>>
--------------
The following is a summary of a novel so far. Read the summary and continue the story.

Summary:

<<SUMMARY>>

Last few lines:

<<NOVEL>>

Write a long continuation of the above story:
--------------
Write a concise summary of the following excerpt:
<<CHUNK>>

Concise summary:
--------------
 * I like the hint word of "excerpt" and "concise"
--------------

[full summary here]

Rephrase this to be more dramatic and emotionally gripping.

--------------

 * append emojis after every sentence to communicate emotion and other actions/nouns in that sentence. The emojis act a miniature summaries of each sentence to reinforce the underlying meaning of the words.
* use Plutchik's wheel of emotions along with emojis to label sentences. Are there distinct emojis for each level? Maybe pair with a qualifier word like: (mild 😒, intense 😠)

-------------

 * use parenthesis to evoke internal monologue about the intent behind the output: (this is symbolic of jealousy)
 * "Prompt: given everything that has happened to the main character, this is their internal monologue:"

------------

[summary]

The following is a sequence of movie scenes (story beats) of an award winning plotline that expands upon the summary above. Each story beat is connected to the other scene either overtly or through symbolism.

[full]

------------

 * when generating the full prompt, search for all caps sequence tags, like THEME STATED:, and inject the Sequence-specific advice to convert it into something like "THEME STATED: (demonstrates the main question or lesson the main character will face)"
 * edge case is when encountering "(CONTINUED)". Need special language to indicate that it builds off the previous original instance of that sequence type.

------------

 * just for the orphanSummary, start the prompt with "Once upon a time"

------------

 * to explore GPT-3's capabilities, what if I start at the very lowest level, and ask it things like "list a sequence of events that logically depend on each other"
 * if the completion makes sense like a dependency graph, then guide it more emotion/story language

------------

Write a short summary of a story for kids/teens/adults about keyword1, keyword2, and keyword3 (NOTE: we need to inject the "and" at the end of the keyword list)

-----------

 * https://beta.openai.com/docs/api-reference/completions/create#completions/create-logit_bias
 * use to increase chances of user-entered keywords and logline words appearing. Could also add "hero name" to the UI, and crank up likelihood of that name appearing along with a prompt of "the main character's name is: John"

-----------
After reading the following sequence of events, write a summary of what happens next:

[full]

Now write a concise summary of what happens next.

<<IDEAL COMPLETION>>
-----------

Express Rate Limit - OpenAI suggests a max of 6 requests per minute (per user?)






LIMITATIONS AND RESTRICTIONS

High-level guidelines... not requirements?

We generally do not permit tools that generate a paragraph or more of natural language or many lines of code, unless the output is of a very specific structure that couldn't be re-purposed for general blog or article generation (e.g., a cover letter, a recipe, song lyrics).

For more scoped use-cases, we tend to recommend an output of around 150 tokens (~6-8 sentences), but it will depend on the specific use-case.

For generative use-cases where the user has considerable control in directing the output, you should generally use the OpenAI Content Filter to prevent 'Unsafe' (CF=2) content.

Rate-limiting end-users’ access to your application is always recommended to prevent automated usage, and to control your costs; there will be more specific guidelines by use-case.


FINETUNING

 * YouTube video on fine-tuning "Bugout dev" suggests 100-200 example rows is sufficient for initial fine-tuning for generative use-cases
 * "Right now, you can fine-tune up to 10 models per month and each dataset can be up to 2.5M tokens or 80-100MB in size"


Out of the Bottle
	Aladin
	LiarLiar
	Fantasia
Monster in the House
	Whiplash
	TheCraft
	JurassicWorld
Golden Fleece
	StarWarsEp4
	TheWizardOfOz
	TheMitchellsVsTheMachines
Superhero
	IronMan
	KungFuPanda
	Ratatouille
Rites of Passage
	HowToTrainYourDragon
	Float
	ACharlieBrownThanksgiving
Fool Triumphant
	Elf
	Moneyball
	TheKingsSpeech
Buddy Love
	MyOctopusTeacher
	BeautyAndTheBeast
	ET
Whydunnit
	CaptainMarvel
	TheBigLebowski
	TheConversation
Institutionalized
	Sicario
	DrStrangelove
	FreeSolo
Unexpected Problem
	TheLegoMovie
	Taken
	DontLookUp


HERO
Caregiver
	ET
Creator
	IronMan
	HowToTrainYourDragon
	TheMitchellsVsTheMachines
Explorer
	Whiplash
	MyOctopusTeacher
	BeautyAndTheBeast
	Ratatouille
	FreeSolo
Innocent
	Elf
	Sicario
	TheLegoMovie
	TheCraft
	TheWizardOfOz
	KungFuPanda
	TheBigLebowski
	DrStrangelove
	ACharlieBrownThanksgiving
Jester
	LiarLiar
Lover
Magician
	Fantasia
Orphan
	Aladin
Outlaw
	CaptainMarvel
	Taken
	Moneyball
Ruler
	JurassicWorld
	TheKingsSpeech
Sage
	DontLookUp
	TheConversation
Warrior
	StarWarsEp4


ENEMY
Caregiver
	Float
	LiarLiar
	FreeSolo
Creator
Explorer
Innocent
	ET
Jester
	Taken
	DrStrangelove
	TheKingsSpeech
Lover
	TheBigLebowski
Magician
	Aladin
	TheCraft
	TheWizardOfOz
Orphan
	MyOctopusTeacher
	TheConversation
Outlaw
	StarWarsEp4
	Sicario
	JurassicWorld
Ruler
	Whiplash
	Elf
	TheLegoMovie
	Moneyball
	BeautyAndTheBeast
	DontLookUp
	TheMitchellsVsTheMachines
	Ratatouille
	ACharlieBrownThanksgiving
Sage
	IronMan
	Fantasia
Warrior
	HowToTrainYourDragon
	CaptainMarvel
	KungFuPanda


Exact Revenge
	CaptainMarvel
	Sicario
	TheCraft
Find Connection
	Aladin
	Elf
	Float
	LiarLiar
	BeautyAndTheBeast
	TheMitchellsVsTheMachines
	ACharlieBrownThanksgiving
	ET
Protect Family
	StarWarsEp4
	HowToTrainYourDragon
	MyOctopusTeacher
	Taken
	DontLookUp
Protect Possession
	IronMan
	KungFuPanda
	DrStrangelove
	TheConversation
Survive
	Whiplash
	TheLegoMovie
	TheWizardOfOz
	Moneyball
	TheBigLebowski
	Fantasia
	JurassicWorld
	Ratatouille
	TheKingsSpeech
	FreeSolo

32854 words total after 30 stories