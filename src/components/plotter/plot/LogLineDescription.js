import Spinner from 'react-bootstrap/Spinner';
import GenreDescription from './GenreDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
import HeroArchetypeDescription from './HeroArchetypeDescription'
import EnemyArchetypeDescription from './EnemyArchetypeDescription'
import PrimalStakesDescription from './PrimalStakesDescription'
import DramaticQuestionDescription from './DramaticQuestionDescription'

const LogLineDescription = (
    {
        curFocusElName,
        descIsLoading,
        genreDescObj,
        problemTemplateDescObj,
        heroArchetypeDescObj,
        enemyArchetypeDescObj,
        primalStakesDescObj,
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
                        curFocusElName === 'hero archetype' && heroArchetypeDescObj && <HeroArchetypeDescription heroArchetypeDescObj={heroArchetypeDescObj} />
                    }
                    {
                        curFocusElName === 'enemy archetype' && enemyArchetypeDescObj && <EnemyArchetypeDescription enemyArchetypeDescObj={enemyArchetypeDescObj} />
                    }
                    {
                        curFocusElName === 'primal stakes' && primalStakesDescObj && <PrimalStakesDescription primalStakesDescObj={primalStakesDescObj} />
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

export default LogLineDescription