import LogLineSelect from './LogLineSelect'
import LogLineDescription from './LogLineDescription'

const Main = ({ logLine, onFocusChange, onGenreChange, onProblemTemplateChange, onKeywordChange, onHeroArchetypeChange, onEnemyArchetypeChange, onPrimalStakesChange, onDramaticQuestionChange }) => {
    const genreOptions = [
        { value: 'scifi', label: 'Scifi' },
        { value: 'fantasy', label: 'Fantasy' },
        { value: 'western', label: 'Western' }
    ]

    const problemTemplateOptions = [
        { value: 'buddy love', label: 'Buddy Love' },
        { value: 'out of the bottle', label: 'Out of the Bottle' }
    ]

    const archetypeOptions = [
        { value: 'jester', label: 'Jester' },
        { value: 'warrior', label: 'Warrior' },
    ]

    const primalStakesOptions = [
        { value: 'find mate', label: 'Find a mate' },
        { value: 'exact revenge', label: 'Exact Revenge' },
    ]

    const dramaticQuestionOptions = [
        { value: 'loyalty', label: 'Loyalty' },
        { value: 'wealth', label: 'Wealth' },
    ]

    return (
        <main>
            <div className='container'>
                <div className='row align-items-md-stretch'>
                    <div className='col-md-6 logline'>
                        <span>I want a </span>

                        <LogLineSelect
                            placeholder='Genre'
                            width='10em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('genre')}
                            options={genreOptions}
                            value={logLine.genre}
                            onChange={onGenreChange}
                        />

                        <LogLineSelect
                            placeholder='Problem Template'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('problem template')}
                            options={problemTemplateOptions}
                            value={logLine.problemTemplate}
                            onChange={onProblemTemplateChange}
                        />

                        <span>story involving</span>

                        <LogLineSelect
                            placeholder='Keywords'
                            width='15em'
                            isMultiSelect={true}
                            onFocusChange={() => onFocusChange('keywords')}
                            value={logLine.keywords}
                            onChange={onKeywordChange}
                        />

                        <span>. The </span>

                        <LogLineSelect
                            placeholder='Hero Archetype'
                            width='10em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('hero archetype')}
                            options={archetypeOptions}
                            value={logLine.heroArchetype}
                            onChange={onHeroArchetypeChange}
                        />

                        <span> hero ultimately seeks to </span>

                        <LogLineSelect
                            placeholder='Primal Stakes'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('primal stakes')}
                            options={primalStakesOptions}
                            value={logLine.primalStakes}
                            onChange={onPrimalStakesChange}
                        />

                        <span> while the </span>

                        <LogLineSelect
                            placeholder='Enemy Archetype'
                            width='10em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('enemy archetype')}
                            options={archetypeOptions}
                            value={logLine.enemyArchetype}
                            onChange={onEnemyArchetypeChange}
                        />

                        <span> enemy attempts to thwart them. The theme of </span>

                        <LogLineSelect
                            placeholder='Dramatic Question'
                            width='10em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('dramatic question')}
                            options={dramaticQuestionOptions}
                            value={logLine.dramaticQuestion}
                            onChange={onDramaticQuestionChange}
                        />

                        <span> occurs throughout the story.</span>
                    </div>
                    <div className='col-md-6'>
                        <LogLineDescription logLine={logLine} />
                    </div>
                </div>
            </div>
        </main >
    )
}

export default Main