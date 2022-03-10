export const getPersonalityDescriptions = (axis) => {

    const descriptions = {
        'closemindedToImaginative': {
            'primary': {
                'left': {
                    'name': 'closeminded',
                    'description': 'preserver, conservative, practical, prefers not to be exposed to alternative moral systems, narrow interests, inartistic, does not question "why?", accepts status quo, down-to-earth'
                },
                'right': {
                    'name': 'imaginative',
                    'description': 'explorer, curious, visionary, enjoys seeing unfamiliar things/strange people, curious, imaginative, untraditional'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'a fuddy-duddy',
                    'description': 'lack of artistry, disdain, dislikes poetry, seldom lost in thought, seldom daydreams, art is pointless'
                },
                'bottom': {
                    'name': 'idea averse',
                    'description': 'mentally resistant to new ideas, ignorant, difficulty understanding abstract ideas, avoids philosophical discussions, avoids challenging reading material, slow learner'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'artsy',
                    'description': 'openess, artistry, reflection, enjoys beauty in nature, deepy moved by music, notices beauty in unexpected places, needs creative outlet'
                },
                'bottom': {
                    'name': 'a brainstormer',
                    'description': 'intellect, ingenuity, quick to understand things, can handle a lot of information, solves complex problems, has rich vocabulary, thinks quickly, formulates clear ideas'
                }
            }
        },
        'disciplinedToSpontaneous': {
            'primary': {
                'left': {
                    'name': 'disciplined',
                    'description': 'focused, organized, ambitious, hardworking, neat, persevering, punctual, self-disciplined'
                },
                'right': {
                    'name': 'spontaneous',
                    'description': 'flexible, spontaneous, multi-tasker, spur-of-the-moment action, unreliable, hedonistic, careless, lax'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'industrious',
                    'description': 'industrious, tries hard, carries out plans, works quickly, finishes what they start'
                },
                'bottom': {
                    'name': 'orderly',
                    'description': 'orderly, neat, perfectionism, punctuality, polices others'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'head in the clouds',
                    'description': 'unfocused, screws things up, wastes time, unmotivated, mind wanders, postpones decisions'
                },
                'bottom': {
                    'name': 'sloppy',
                    'description': 'messy, not bothered by disorder, imprecise, late, dislikes routine'
                }
            }
        },
        'introvertToExtrovert': {
            'primary': {
                'left': {
                    'name': 'introvert',
                    'description': 'introvert, private, reserved, sober, aloof, unenthusiastic'
                },
                'right': {
                    'name': 'extrovert',
                    'description': 'extrovert, social, enthusiastic, partier, optimistic, fun-loving, affectionate'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'glum',
                    'description': 'apathetic, glum, loner, hard to get to know, keeps others at a distance, reveals little about self, not caught up in excitement'
                },
                'bottom': {
                    'name': 'submissive',
                    'description': 'passive, submissive, follower, holds back opinions, can\'t influence others, unconvincing'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'gung-ho',
                    'description': 'enthusiasm, makes friends, sociability, warms up to others, laughs a lot'
                },
                'bottom': {
                    'name': 'bossy',
                    'description': 'assertiveness, dominance, leadership, takes charge, coerces others, captivates and convinces others, thinks highly of own leadership'
                }
            }
        },
        'coldToEmpathetic': {
            'primary': {
                'left': {
                    'name': 'cold',
                    'description': 'challenger, competitive, fighter, asserts own rights, irritable, manipulative, uncooperative, rude'
                },
                'right': {
                    'name': 'empathetic',
                    'description': 'adapter, team player, helper, agreeable, good-natured, forgiving, gullible'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'unfeeling',
                    'description': 'disinterest in others problems, unfeeling, no time for others, does not have a soft side'
                },
                'bottom': {
                    'name': 'rude',
                    'description': 'rude, rebellious, selfish, feels superior to others, likes a good fight, takes advantage of others'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'compassionate',
                    'description': 'compassion, empathy, concerned about others\' well-being, sympathy, does nice things for others'
                },
                'bottom': {
                    'name': 'polite',
                    'description': 'polite, respects authority, avoids being pushy, rarely pressures others'
                }
            }
        },
        'unflappableToAnxious': {
            'primary': {
                'left': {
                    'name': 'unflappable',
                    'description': 'resilient, controlled, stress-free, calm, unemotional, hardy, secure, self-satisfied'
                },
                'right': {
                    'name': 'anxious',
                    'description': 'reactive, tense, anxious, alert, worrying, insecure, hypochondriacal, feels inadequate'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'impervious',
                    'description': 'emotionally stable, impervious, maintains composure, not easily annoyed'
                },
                'bottom': {
                    'name': 'relaxed',
                    'description': 'attentive to current moment, relaxed, self-assured, unsuseptible, self-secure, not easily embarrassed'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'volatile',
                    'description': 'volatile, irritable, angry, agitated, frequent mood swings'
                },
                'bottom': {
                    'name': 'vulnerable',
                    'description': 'withdrawn, anxious, depressed, vulnerable, frequent doubts, feels threatened easily, easily discouraged, overwhelmed by events, afraid of everything'
                }
            }
        }
    }

    return descriptions[axis]
}