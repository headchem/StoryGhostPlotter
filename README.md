In VSCode menu "Run and Debug"
	Debug "Attach to .NET Functions"
	Once it starts, then select "SWA: Run..." and Debug

to build for prod and see if there are any linting error before deploying, run the following:
npm run build

convert plotter C# webservice into Function
basic UI, same as left-most col in plotter, but other columns are hidden
The data returned by the webservice is stored in 16-level tree
At the start, you must commit to the initial parameters, because changing them after fragments have been generated will not have any consistency
With fixed initial preferences set, now UI goes one by one through each of the 16 "pages"
On each page, send the prompt to GPT-3. if you don't like it, generate another alternative, but the previous ones still persist so you can go back to them. Each time you generate, it creates a new leaf node in the tree.
When you find text you like, you then advance to the next "page" and repeat.
As you advance pages, it just adds to what is visible in the UI, so you can always see the entire story that came before
If you go back and change a page in the middle, it will clear out any future pages that were already generated, presenting "generate new" for each, but you can always reselect previously generated pages to rebuild the tree
if there is only 1 child, then show it, otherwise, show the blank generate UI
for now, create a wrapper Function to mock the GPT-3 call. Might want this permanently, so I can swap between GPT-3, EleutherAI GPT-J etc. Moat potential as I can hide the generated prompts behind server-side
Each of the 16 pages lets the author first write their own "what happens next" Once an idea strikes, get out of the way and let them carry it forward, but the option is always there to write something custom, then ask GPT-3 to continue the idea. This means the default UI is always a blank page with a text area, click a button to have GPT-3 fill it in, paginate through different ideas that widen this level of the branching timeline tree
Hype/marketing - every time someone completes all 16 pages, update a global NoSQL container counter. This metric is more valuable than anything from Google Analytics for measuring success
Put an arbitrary limit of the number of variations you're allowed to have for a page. For choice between, say, 2 variations to reduce paralysis of choice, and if you want more, you must delete another one (and all later descendents)
After GPT-3 fills a page with an idea, now encourage the author to make tweaks like a co-author brainstorm. Human needs to be part of the process like an editor forging the ideas into something even better

Slot machine interface? Any real world widgets that have several dropdown-like interactions?

send Log Line inputs to webservice Function, add basic validation making all fields required. Ultimately, the response to the user will be the finished 16 Sequences.
	In Function:
		given Log Line inputs, craft GPT-3 Log Line prompt and get result
		Log Line result becomes the starting context for the final Sequence prompt and result, which also merges in all structure language from Hero Stage and Sequence Type.
		Each Sequence result is chained into the next prompt, which hopefully serves as GPT-3's memory to keep the story consistent.

LEFT OFF:
Research good descriptions and keywords for Primal Stakes and Genres (setting). Might as well fully flesh out primal stakes since there are only 5, and pick top 5ish Genres to have complete prompt data available for next step.
Research GPT-3 prompt best practices, examples of finetuning (and cost?). Can I manually label the plot synopsis dataset with the Log Line params?
Move on to GenerateLogLinePrompt. Consider using an abstract grammar that gets populated by parameters, or maybe mad-libs style is good enough?
Once we are getting responses from GPT-3, set up KeyVault integration for OpenAI key and db connection strings, log GPT responses to a db. This db can be used to manually review and use to further finetune the model to improve future output. Same db can be used to manually label the movie synopsis dataset. Bool cols for IsGenerated and IsGoodForFinetuning (default false for generated text, once I manually review I can choose to flip it)

GPT-3 prompt examples: https://beta.openai.com/examples
	Summarize for a 2nd grader
	Micro horror story creator
	Essay outline
	