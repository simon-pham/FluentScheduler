﻿namespace FluentScheduler.UnitTests
{
    using Xunit;
    using System;
    using static Xunit.Assert;

    public class DaysWeekDaysOnlyTests
    {
        [Fact]
        public void Should_Pick_Same_Day_If_Now_Is_In_Time_On_Friday()
        {
            // Arrange
            var input = new DateTime(1999, 12, 31, 1, 23, 25);
            var expected = new DateTime(1999, 12, 31, 3, 15, 0);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(1).Days().At(3, 15).WeekdaysOnly();
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
            Equal(DayOfWeek.Friday, input.DayOfWeek);
            Equal(DayOfWeek.Friday, actual.DayOfWeek);
        }

        [Fact]
        public void Should_Pick_Monday_If_Now_Is_Too_Late_On_Friday()
        {
            // Arrange
            var input = new DateTime(1999, 12, 31, 12, 23, 25);
            var expected = new DateTime(2000, 1, 3, 3, 15, 0);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(1).Days().At(3, 15).WeekdaysOnly();
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
            Equal(DayOfWeek.Friday, input.DayOfWeek);
            Equal(DayOfWeek.Monday, actual.DayOfWeek);
        }

        [Fact]
        public void Should_Pick_Monday_If_Now_Is_Saturday()
        {
            // Arrange
            var input = new DateTime(2000, 1, 1, 1, 23, 25);
            var expected = new DateTime(2000, 1, 3, 3, 15, 0);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(1).Days().At(3, 15).WeekdaysOnly();
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
            Equal(DayOfWeek.Saturday, input.DayOfWeek);
            Equal(DayOfWeek.Monday, actual.DayOfWeek);
        }

        [Fact]
        public void Should_Pick_Monday_If_Now_Is_Sunday()
        {
            // Arrange
            var input = new DateTime(2000, 1, 2, 1, 23, 25);
            var expected = new DateTime(2000, 1, 3, 3, 15, 0);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(1).Days().At(3, 15).WeekdaysOnly();
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
            Equal(DayOfWeek.Sunday, input.DayOfWeek);
            Equal(DayOfWeek.Monday, actual.DayOfWeek);
        }

        [Fact]
        public void Should_Pick_Tuesday_If_Now_Is_Too_Late_Monday()
        {
            // Arrange
            var input = new DateTime(2000, 1, 3, 12, 23, 25);
            var expected = new DateTime(2000, 1, 4, 3, 15, 0);

            // Act
            var schedule = new Schedule(() => { });
            schedule.ToRunEvery(1).Days().At(3, 15).WeekdaysOnly();
            var actual = schedule.CalculateNextRun(input);

            // Assert
            Equal(expected, actual);
            Equal(DayOfWeek.Monday, input.DayOfWeek);
            Equal(DayOfWeek.Tuesday, actual.DayOfWeek);
        }
    }
}
