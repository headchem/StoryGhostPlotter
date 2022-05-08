import { Link } from "react-router-dom";

const About = () => {
    return (
        <div className='fs-5'>
            <p>
                Story Ghost is a highly opinionated tool to help writers craft compelling plot lines. If you are a "pantser" - someone who writes by the seat of their pants - you will find this tool frustrating. If you are a "plotter" - someone who benefits from carefully planning outlines and hitting emotional targets at prescribed moments - Story Ghost is for you!
            </p>
            <p>
                In addition to structured plotting, our longterm goal is to train an AI to assist in the brainstorming process. The nature of AI transformer models is that they write like a "pantser". We hope Story Ghost combines the best of both the plotter and pantser styles to help you quickly formulate structurally sound and creative stories. However, Story Ghost is designed to be a helpful tool even without the AI features.
            </p>
            <p>
                Legalese: You own your words! Improving the AI requires us to have access to your writing, to include in the model training process. Please refrain from writing content you would not want associated with your identity. We will never share your stories publically - unless you opt in. All stories are private by default, but may be accessed by Story Ghost admins. We depend on Open AI's GPT-3 API, which has <a target="_blank" rel="noreferrer" href="https://beta.openai.com/docs/usage-guidelines/content-policy">strict usage policies</a>. Your writing is subject to removal if it violates these policies.
            </p>
            <Link className="btn btn-primary fs-4 mt-5" to="/plots">Go To My Plots</Link>
        </div>
    )
}

export default About
