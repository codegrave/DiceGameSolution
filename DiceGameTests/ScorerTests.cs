using System;
using DiceGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceGameTests
{
    [TestClass]
    public class ScorerTests
    {
        [TestMethod]
        public void Should_be_initialized()
        {
            var sut = new Scorer();

            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public void Category_ones_should_sum_all_the_ones()
        {
            const int expected = 2;
            var sut = new Scorer();
            var role = new Role(1, 3, 5, 7, 1);
            var sum = sut.Score(Category.Ones, role);

            Assert.AreEqual(expected, sum);
        }

        [TestMethod]
        public void Category_twos_should_sum_all_the_twos()
        {
            const int expected = 2;
            var sut = new Scorer();
            var role = new Role(1, 3, 4, 7, 2);
            var sum = sut.Score(Category.Twos, role);

            Assert.AreEqual(expected, sum);
        }

        [TestMethod]
        public void Category_threes_should_sum_all_the_threes()
        {
            const int expected = 9;
            var sut = new Scorer();
            var role = new Role(3, 3, 4, 7, 3);
            var sum = sut.Score(Category.Threes, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_fours_should_sum_all_the_fours()
        {
            const int expected = 8;
            var sut = new Scorer();
            var role = new Role(4, 3, 4, 7, 1);
            var sum = sut.Score(Category.Fours, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_fives_should_sum_all_the_fives()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(8, 3, 4, 7, 1);
            var sum = sut.Score(Category.Fives, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_sixes_should_sum_all_the_sixes()
        {
            const int expected = 18;
            var sut = new Scorer();
            var role = new Role(8, 6, 6, 7, 6);
            var sum = sut.Score(Category.Sixes, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_sevens_should_sum_all_the_sevens()
        {
            const int expected = 7;
            var sut = new Scorer();
            var role = new Role(8, 1, 3, 7, 6);
            var sum = sut.Score(Category.Sevens, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_eights_should_sum_all_the_eights()
        {
            const int expected = 16;
            var sut = new Scorer();
            var role = new Role(8, 1, 3, 7, 8);
            var sum = sut.Score(Category.Eights, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_threeofakind_should_sum_all_when_there_are_3_or_more_of_the_same()
        {
            const int expected = 24;
            var sut = new Scorer();
            var role = new Role(8, 3, 3, 7, 3);
            var sum = sut.Score(Category.ThreeOfAKind, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_threeofakind_should_be_0_otherwise()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(8, 1, 3, 1, 3);
            var sum = sut.Score(Category.ThreeOfAKind, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_fourofakind_should_sum_all_when_there_are_4_or_more_of_the_same()
        {
            const int expected = 19;
            var sut = new Scorer();
            var role = new Role(3, 3, 3, 7, 3);
            var sum = sut.Score(Category.FourOfAKind, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_fourofakind_should_be_0_otherwise()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(8, 1, 3, 1, 3);
            var sum = sut.Score(Category.FourOfAKind, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_allofakind_should_be_50_all_of_the_dice_are_the_same()
        {
            const int expected = 50;
            var sut = new Scorer();
            var role = new Role(3, 3, 3, 3, 3);
            var sum = sut.Score(Category.AllOfAKind, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_allofakind_should_be_0_otherwise()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(3, 3, 3, 3, 1);
            var sum = sut.Score(Category.AllOfAKind, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_noneofakind_should_be_40_when_there_are_no_duplicate_dice()
        {
            const int expected = 40;
            var sut = new Scorer();
            var role = new Role(1, 2, 3, 5, 8);
            var sum = sut.Score(Category.NoneOfAKind, role);

            Assert.AreEqual(expected, sum);
        }

        [TestMethod]
        public void Category_noneofakind_should_be_0_otherwise()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(1, 2, 3, 5, 5);
            var sum = sut.Score(Category.NoneOfAKind, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_fullhouse_should_be_25_when_there_are_2_duplicate_one_and_3_duplicate_another()
        {
            const int expected = 25;
            var sut = new Scorer();
            var role = new Role(1, 1, 3, 3, 3);
            var sum = sut.Score(Category.FullHouse, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_fullhouse_should_be_0_otherwise()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(1, 1, 3, 3, 5);
            var sum = sut.Score(Category.FullHouse, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_smallstraight_should_be_30_when_there_are_4_or_more_dice_in_sequence()
        {
            const int expected = 30;
            var sut = new Scorer();
            var role = new Role(4, 2, 8, 1, 3);
            var sum = sut.Score(Category.SmallStraight , role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_smallstraight_should_be_0_otherwise()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(5, 1, 3, 7, 2);
            var sum = sut.Score(Category.SmallStraight, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_largestraight_should_be_40_when_there_are_5_dice_in_sequence()
        {
            const int expected = 40;
            var sut = new Scorer();
            var role = new Role(5, 6, 4, 2, 3);
            var sum = sut.Score(Category.LargeStraight, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_largestraight_should_be_0_otherwise()
        {
            const int expected = 0;
            var sut = new Scorer();
            var role = new Role(5, 6, 8, 2, 3);
            var sum = sut.Score(Category.LargeStraight, role);

            Assert.AreEqual(expected, sum);
        }
        [TestMethod]
        public void Category_chance_should_sum_of_all_dice()
        {
            const int expected = 24;
            var sut = new Scorer();
            var role = new Role(5, 6, 8, 2, 3);
            var sum = sut.Score(Category.Chance, role);

            Assert.AreEqual(expected, sum);
        }

        //// AllScores Tests
        [TestMethod]
        // Chance > Eights, Sevens, Sixes, Fives, Fours, Threes, Onces
        // ThreeOfKind == Chance
        public void Should_return_14_with_threeofkind_or_chance()
        {
            var sut = new Scorer();
            var role = new Role(2, 2, 2, 7, 1);
            var scores = sut.AllScores(role);

            Assert.AreEqual(14, scores[0].Score);
        }
        [TestMethod]
        public void Should_return_50_with_allofakind()
        {
            var sut = new Scorer();
            var role = new Role(1, 1, 1, 1, 1);
            var scores = sut.AllScores(role);

            Assert.AreEqual(50, scores[0].Score);
        }
        [TestMethod]
        public void Should_return_40_with_noneofakind()
        {
            var sut = new Scorer();
            var role = new Role(5, 6, 8, 2, 3);
            var scores = sut.AllScores(role);

            Assert.AreEqual(40, scores[0].Score);
        }
        [TestMethod]
        public void Should_return_25_with_fullhouse()
        {
            var sut = new Scorer();
            var role = new Role(1, 1, 1, 2, 2);
            var scores = sut.AllScores(role);

            Assert.AreEqual(25, scores[0].Score);
        }
        [TestMethod]
        public void Should_return_30_with_smallstraight()
        {
            var sut = new Scorer();
            var role = new Role(4, 5, 3, 2, 2);
            var scores = sut.AllScores(role);

            Assert.AreEqual(30, scores[0].Score);
        }
        [TestMethod]
        public void Should_return_40_with_largestraight()
        {
            var sut = new Scorer();
            var role = new Role(4, 5, 6, 8, 7);
            var scores = sut.AllScores(role);

            Assert.AreEqual(40, scores[0].Score);
        }
        [TestMethod]
        public void Should_return_36_with_chance()
        {
            var sut = new Scorer();
            var role = new Role(8, 8, 7, 7, 6);
            var scores = sut.AllScores(role);

            Assert.AreEqual(36, scores[0].Score);
        }
    }
}
