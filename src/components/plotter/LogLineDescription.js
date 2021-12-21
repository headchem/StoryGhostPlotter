import GenreDescription from './GenreDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
import HeroArchetypeDescription from './HeroArchetypeDescription'
import EnemyArchetypeDescription from './EnemyArchetypeDescription'
import PrimalStakesDescription from './PrimalStakesDescription'
import DramaticQuestionDescription from './DramaticQuestionDescription'

const LogLineDescription = ({ logLine }) => {

    return (
        <div>
            {
                logLine.descIsLoading === true && <p>loading...</p>
            }
            {
                logLine.descIsLoading === false && <>
                    <h3>Show full description for current focus: {logLine.curFocusElName}</h3>
                    {
                        logLine.curFocusElName === 'genre' && <GenreDescription logLine={logLine} />
                    }
                    {
                        logLine.curFocusElName === 'problem template' && <ProblemTemplateDescription logLine={logLine} />
                    }
                    {
                        logLine.curFocusElName === 'hero archetype' && <HeroArchetypeDescription logLine={logLine} />
                    }
                    {
                        logLine.curFocusElName === 'enemy archetype' && <EnemyArchetypeDescription logLine={logLine} />
                    }
                    {
                        logLine.curFocusElName === 'primal stakes' && <PrimalStakesDescription logLine={logLine} />
                    }
                    {
                        logLine.curFocusElName === 'dramatic question' && <DramaticQuestionDescription logLine={logLine} />
                    }
                </>
            }
        </div>
    )
}

export default LogLineDescription