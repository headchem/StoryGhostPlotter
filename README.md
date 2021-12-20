In VSCode menu "Run and Debug"
	Debug "Attach to .NET Functions"
	Once it starts, then select "SWA: Run..." and Debug

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

LEFT OFF: continue with tutorial video adding server-side interaction with my C# Function instead, and React Routing
Slot machine interface? Any real world widgets that have several dropdown-like interactions?