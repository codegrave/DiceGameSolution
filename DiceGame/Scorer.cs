using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public enum Category
    {
        Ones = 0,
        Twos,
        Threes,
        Fours,
        Fives,
        Sixes,
        Sevens,
        Eights,
        ThreeOfAKind,
        FourOfAKind,
        AllOfAKind,
        NoneOfAKind,
        FullHouse,
        SmallStraight,
        LargeStraight,
        Chance
    }

    public struct Role : IEnumerable<byte>
    {
        private readonly byte[] _dices;

        public Role(byte dice1, byte dice2, byte dice3, byte dice4, byte dice5)
        {
            if (dice1 > 8 || dice2 > 8 || dice3 > 8 || dice4 > 8 || dice5 > 8)
            {
                throw new InvalidOperationException("dice cannot be greater than 8");
            }
            _dices = new[] {dice1, dice2, dice3, dice4, dice5};
            Array.Sort(_dices);
        }

        public byte this[int index]
        {
            get
            {
                if (index < 1 || index > 5)
                {
                    throw new InvalidOperationException("index should be between 1 and 5");
                }
                return _dices[index - 1];
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return ((IEnumerable<byte>) _dices).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public byte ScoreOnes()
        {
            return (byte)_dices.Where(r => r == 1).Sum(r => r);
        }
        public byte ScoreTwos()
        {
            return (byte)_dices.Where(r => r == 2).Sum(r => r);
        }
        public byte ScoreThrees()
        {
            return (byte) _dices.Where(r => r == 3).Sum(r => r);
        }
        public byte ScoreFours()
        {
            return (byte)_dices.Where(r => r == 4).Sum(r => r);
        }
        public byte ScoreFives()
        {
            return (byte) _dices.Where(r => r == 5).Sum(r => r);
        }
        public byte ScoreSixes()
        {
            return (byte)_dices.Where(r => r == 6).Sum(r => r);
        }
        public byte ScoreSevens()
        {
            return (byte)_dices.Where(r => r == 7).Sum(r => r);
        }
        public byte ScoreEights()
        {
            return (byte)_dices.Where(r => r == 8).Sum(r => r);
        }
        public byte ScoreThreeOfAKind()
        {
            if (_dices.GroupBy(r => r).Any(r => r.Count() == 3))
            {
                return (byte) _dices.Sum(r => r);
            }
            return 0;
        }
        public byte ScoreFourOfAKind()
        {
            if (_dices.GroupBy(r => r).Any(r => r.Count() == 4))
            {
                return (byte) _dices.Sum(r => r);
            }
            return 0;
        }
        public byte ScoreAllOfAKind()
        {
            if (_dices.GroupBy(r => r).Any(r => r.Count() == 5))
            {
                return 50;
            }
            return 0;
        }
        public byte ScoreNoneOfAKind()
        {
            if (!_dices.GroupBy(r => r).Any(r => r.Count() >= 2))
            {
                return 40;
            }
            return 0;
        }
        public byte ScoreFullHouse()
        {
            if (_dices.GroupBy(r => r).Any(r => r.Count() == 2)
                && _dices.GroupBy(r => r).Any(r => r.Count() == 3))
            {
                return 25;
            }
            return 0;
        }
        public byte ScoreSmallStraight()
        {
            var diceFirst4 = new byte[4];
            Array.Copy(_dices, 0, diceFirst4, 0, 4);
            var diceLast4 = new byte[4];
            Array.Copy(_dices, 1, diceLast4, 0, 4);
            if (diceFirst4.Zip(diceFirst4.Skip(1), (a, b) => (a + 1) == b).All(x => x)
                || diceLast4.Zip(diceLast4.Skip(1), (a, b) => (a + 1) == b).All(x => x))
            {
                return 30;
            }
            return 0;
        }
        public byte ScoreLargeStraight()
        {
            if (_dices.Zip(_dices.Skip(1), (a, b) => (a + 1) == b).All(x => x))
            {
                return 40;
            }
            return 0;
        }
        public byte ScoreChance()
        {
            return (byte)_dices.Sum(r => r);
        }
    }

    public class Scorer
    {
        public byte Score(Category category, Role role)
        {
            switch (category)
            {
                case Category.Ones:
                    return role.ScoreOnes();
                case Category.Twos:
                    return role.ScoreTwos();
                case Category.Threes:
                    return role.ScoreThrees();
                case Category.Fours:
                    return role.ScoreFours();
                case Category.Fives:
                    return role.ScoreFives();
                case Category.Sixes:
                    return role.ScoreSixes();
                case Category.Sevens:
                    return role.ScoreSevens();
                case Category.Eights:
                    return role.ScoreEights();
                case Category.ThreeOfAKind:
                    return role.ScoreThreeOfAKind();
                case Category.FourOfAKind:
                    return role.ScoreFourOfAKind();
                case Category.AllOfAKind:
                    return role.ScoreAllOfAKind();
                case Category.NoneOfAKind:
                    return role.ScoreNoneOfAKind();
                case Category.FullHouse:
                    return role.ScoreFullHouse();
                case Category.SmallStraight:
                    return role.ScoreSmallStraight();
                case Category.LargeStraight:
                    return role.ScoreLargeStraight();
                case Category.Chance:
                    return role.ScoreChance();
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        public RoleResult[] AllScores(Role role)
        {
            var scores = new List<RoleResult>();
            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                var typedCategory = (Category)category;
                scores.Add(new RoleResult(typedCategory, Score(typedCategory, role)));
            }

            return scores
                .OrderByDescending(s => s.Score)
                .ThenByDescending(s => s.Category)
                .ToArray();
        }
    }

    public struct RoleResult
    {
        public Category Category { get; private set; }
        public byte Score { get; private set; }

        public RoleResult(Category category, byte score)
        {
            Category = category;
            Score = score;
        }
    }
}

