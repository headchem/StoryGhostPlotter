using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Genres;

public class Urban : IGenre
{
    public string Id { get { return GenresEnum.Urban; } }
    public string Name { get { return "Urban"; } }
    public string Description { get { return "Urban fiction, also known as street lit or street fiction, is a literary genre set in a city landscape; however, the genre is as much defined by the socio-economic realities and culture of its characters as the urban setting. The tone for urban fiction is usually dark, focusing on the underside of city living."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                
            };

            return listWithDupes.Distinct().ToList();
        }
    }

    public SequenceAdvices AdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    OpeningImage = "Show it's a gritty urban environment."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}