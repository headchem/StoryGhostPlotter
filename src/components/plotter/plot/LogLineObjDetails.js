import Spinner from 'react-bootstrap/Spinner';
import GenreDescription from './GenreDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
import DramaticQuestionDescription from './DramaticQuestionDescription'

const LogLineObjDetails = (
    {
        curFocusElName,
        descIsLoading,
        genreDescObj,
        problemTemplateDescObj,
        dramaticQuestionDescObj
    }
) => {

    return (
        <div>
            {
                descIsLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                descIsLoading === false && <>
                    {
                        curFocusElName === 'genre' && genreDescObj !== null && <GenreDescription genreDescObj={genreDescObj} />
                    }
                    {
                        curFocusElName === 'problem template' && problemTemplateDescObj && <ProblemTemplateDescription problemTemplateDescObj={problemTemplateDescObj} />
                    }
                    {
                        curFocusElName === 'dramatic question' && dramaticQuestionDescObj && <DramaticQuestionDescription dramaticQuestionDescObj={dramaticQuestionDescObj} />
                    }
                    {
                        curFocusElName === 'keywords' &&
                        <>
                            <p>Enter 3-5 core concepts this story relies upon. For example:</p>
                            <ul>
                                <li>magic ring</li>
                                <li>spaceship</li>
                                <li>deception</li>
                                <li>The Chosen One</li>
                                <li>shame</li>
                            </ul>
                        </>
                    }
                    {
                        curFocusElName === 'log line prompt' &&
                        <></>
                    }
                </>
            }
        </div>
    )
}

export default LogLineObjDetails