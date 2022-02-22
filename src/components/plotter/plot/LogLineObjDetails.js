import Spinner from 'react-bootstrap/Spinner';
import GenreDescription from './GenreDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
//import ArchetypeDescription from './ArchetypeDescription'
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
                            <p>Description about best types of keywords...</p>
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