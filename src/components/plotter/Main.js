import LogLineSelect from './LogLineSelect'
import LogLineDescription from './LogLineDescription'
import LogLinePrompt from './LogLinePrompt'

const Main = (
    {
        curFocusElName,
        genre,
        problemTemplate,
        keywords,
        heroArchetype,
        enemyArchetype,
        primalStakes,
        dramaticQuestion,
        
        descIsLoading,
        genreDescObj,
        problemTemplateDescObj,
        heroArchetypeDescObj,
        enemyArchetypeDescObj,
        primalStakesDescObj,
        dramaticQuestionDescObj,
        logLinePromptIsLoading,
        logLinePrompt,

        onFocusChange,
        onGenreChange,
        onProblemTemplateChange,
        onKeywordChange,
        onHeroArchetypeChange,
        onEnemyArchetypeChange,
        onPrimalStakesChange,
        onDramaticQuestionChange
    }
) => {
    const genreOptions = [
        { value: 'romance', label: 'Romance' },
        { value: 'fantasy', label: 'Fantasy' },
        { value: 'adventure', label: 'Adventure' },
        { value: 'mystery', label: 'Mystery' },
        { value: 'chick-lit', label: 'Chick-lit' },
        { value: 'animals', label: 'Animals' },
        { value: 'historical-romance', label: 'Historical-romance' },
        { value: 'horror', label: 'Horror' },
        { value: 'scifi', label: 'Scifi' },
        { value: 'modern', label: 'Modern' },
        { value: 'war', label: 'War' },
        { value: 'vampires', label: 'Vampires' },
        { value: 'historical', label: 'Historical' },
        { value: 'sports', label: 'Sports' },
        { value: 'western', label: 'Western' },
        { value: 'cowboy-romance', label: 'Cowboy-romance' },
    ]

    const problemTemplateOptions = [
        { value: 'buddy love', label: 'Buddy Love' },
        { value: 'fool triumphant', label: 'Fool Triumphant' },
        { value: 'golden fleece', label: 'Golden Fleece' },
        { value: 'institutionalized', label: 'Institutionalized' },
        { value: 'monster in the house', label: 'Monster In The House' },
        { value: 'out of the bottle', label: 'Out of the Bottle' },
        { value: 'rites of passage', label: 'Rites of Passage' },
        { value: 'superhero', label: 'Superhero' },
        { value: 'unexpected problem', label: 'Unexpected Problem' },
        { value: 'whydunnit', label: 'Whydunnit' },
    ]

    const archetypeOptions = [
        { value: 'caregiver', label: 'Caregiver' },
        { value: 'creator', label: 'Creator' },
        { value: 'explorer', label: 'Explorer' },
        { value: 'innocent', label: 'Innocent' },
        { value: 'jester', label: 'Jester' },
        { value: 'lover', label: 'Lover' },
        { value: 'magician', label: 'Magician' },
        { value: 'orphan', label: 'Orphan' },
        { value: 'outlaw', label: 'Outlaw' },
        { value: 'ruler', label: 'Ruler' },
        { value: 'sage', label: 'Sage' },
        { value: 'warrior', label: 'Warrior' },
    ]

    const primalStakesOptions = [
        { value: 'exact revenge', label: 'Exact Revenge' },
        { value: 'find mate', label: 'Find a mate' },
        { value: 'protect family', label: 'Protect Family' },
        { value: 'protect possession', label: 'Protect Possession' },
        { value: 'survive', label: 'Survive' },
    ]

    const dramaticQuestionOptions = [
        { value: 'bravery', label: 'Bravery' },
        { value: 'consciousness', label: 'Consciousness' },
        { value: 'liberty', label: 'Liberty' },
        { value: 'love', label: 'Love' },
        { value: 'love-alt', label: 'Love-Alt' },
        { value: 'loyalty', label: 'Loyalty' },
        { value: 'maturity', label: 'Maturity' },
        { value: 'natural unsanctioned', label: 'Natural Unsanctioned' },
        { value: 'sanctioned unnatural', label: 'Sanctioned Unnatural' },
        { value: 'open communication', label: 'Open Communication' },
        { value: 'success', label: 'Success' },
        { value: 'truth', label: 'Truth' },
        { value: 'wealth', label: 'Wealth' },
        { value: 'wisdom', label: 'Wisdom' },
    ]

    return (
        <main>
            <div className='container'>
                <div className='row align-items-md-stretch'>
                    <div className='col-md-6 logline'>
                        <span>I want a </span>

                        <LogLineSelect
                            placeholder='Genre'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('genre')}
                            options={genreOptions}
                            value={genre}
                            onChange={onGenreChange}
                        />

                        <LogLineSelect
                            placeholder='Problem Template'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('problem template')}
                            options={problemTemplateOptions}
                            value={problemTemplate}
                            onChange={onProblemTemplateChange}
                        />

                        <span>story involving</span>

                        <LogLineSelect
                            placeholder='Keywords'
                            width='20em'
                            isMultiSelect={true}
                            onFocusChange={() => onFocusChange('keywords')}
                            value={keywords}
                            onChange={onKeywordChange}
                        />

                        <span>. The </span>

                        <LogLineSelect
                            placeholder='Hero Archetype'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('hero archetype')}
                            options={archetypeOptions}
                            value={heroArchetype}
                            onChange={onHeroArchetypeChange}
                        />

                        <span> hero ultimately seeks to </span>

                        <LogLineSelect
                            placeholder='Primal Stakes'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('primal stakes')}
                            options={primalStakesOptions}
                            value={primalStakes}
                            onChange={onPrimalStakesChange}
                        />

                        <span> while the </span>

                        <LogLineSelect
                            placeholder='Enemy Archetype'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('enemy archetype')}
                            options={archetypeOptions}
                            value={enemyArchetype}
                            onChange={onEnemyArchetypeChange}
                        />

                        <span> enemy attempts to thwart them. The theme of </span>

                        <LogLineSelect
                            placeholder='Dramatic Question'
                            width='15em'
                            isMultiSelect={false}
                            onFocusChange={() => onFocusChange('dramatic question')}
                            options={dramaticQuestionOptions}
                            value={dramaticQuestion}
                            onChange={onDramaticQuestionChange}
                        />

                        <span> occurs throughout.</span>
                    </div>
                    <div className='col-md-6'>
                        <LogLineDescription
                            curFocusElName={curFocusElName}
                            descIsLoading={descIsLoading}

                            genreDescObj={genreDescObj}
                            problemTemplateDescObj={problemTemplateDescObj}
                            heroArchetypeDescObj={heroArchetypeDescObj}
                            enemyArchetypeDescObj={enemyArchetypeDescObj}
                            primalStakesDescObj={primalStakesDescObj}
                            dramaticQuestionDescObj={dramaticQuestionDescObj}
                        />
                    </div>
                </div>
                <div className='row'>
                    <LogLinePrompt logLinePromptIsLoading={logLinePromptIsLoading} logLinePrompt={logLinePrompt} />
                </div>
            </div>
        </main >
    )
}

export default Main