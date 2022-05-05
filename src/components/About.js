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
                Legalese: You own your words! <strong>However, training an AI requires your fantastic writing to improve the model.</strong> Please be aware that we may include your stories in our <em>internal</em> AI training processes. We will never share your stories publically - unless you opt in. All stories are private by default.
            </p>
            <Link className="btn btn-primary fs-4 mt-5" to="/plots">Go To My Plots</Link>
        </div>
    )
}

export default About
