using System;
using System.Linq;
using IIG.BinaryFlag;
using Xunit;

namespace Lab2
{
    public class MultipleBinaryFlagTest
    {
        [Fact]
        public void CreateNewMultipleBinaryFlag()
        {
            var flag1 = new MultipleBinaryFlag(2);
            var flag2 = new MultipleBinaryFlag(543, true);
            var flag3 = new MultipleBinaryFlag(1717986, false);
            var flag4 = new MultipleBinaryFlag(17179868704);

            var expected1 = string.Concat(Enumerable.Repeat("T", 2));
            var expected2 = string.Concat(Enumerable.Repeat("T", 543));
            var expected3 = string.Concat(Enumerable.Repeat("F", 1717986));

            Assert.Equal(expected1, flag1.ToString());
            Assert.Equal(expected2, flag2.ToString());
            Assert.Equal(expected3, flag3.ToString());
            Assert.IsType<MultipleBinaryFlag>(flag4);
        }

        [Fact]
        public void CreateNewMultipleBinaryFlag_ToFail_WithBiggerThanMaxLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868705));
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(23423423423, false));
        }

        [Fact]
        public void CreateNewMultipleBinaryFlag_ToFail_WithLessThanMinLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(1, false));
        }

        [Fact]
        public void CreateNewMultipleBinaryFlag_ToFail_WithZeroLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(0));
        }

        [Fact]
        public void SetFlag_WithCorrectIndex()
        {
            var flag = new MultipleBinaryFlag(40, false);

            flag.SetFlag(0);
            flag.SetFlag(12);
            flag.SetFlag(39);
            var expected = "T" + string.Concat(Enumerable.Repeat("F", 11)) + "T"
                           + string.Concat(Enumerable.Repeat("F", 26)) + "T";

            Assert.Equal(expected, flag.ToString());
        }

        [Fact]
        public void SetFlag_ToFail_WithBiggerIndexThanLength()
        {
            var flag = new MultipleBinaryFlag(40, false);
            Assert.Throws<ArgumentOutOfRangeException>(() => flag.SetFlag(40));
            Assert.Throws<ArgumentOutOfRangeException>(() => flag.SetFlag(44));
        }

        [Fact]
        public void ResetFlag_WithCorrectIndex()
        {
            var flag = new MultipleBinaryFlag(10);

            flag.ResetFlag(0);
            flag.ResetFlag(8);
            flag.ResetFlag(9);
            var expected = "F" + string.Concat(Enumerable.Repeat("T", 7)) + "FF";

            Assert.Equal(expected, flag.ToString());
        }

        [Fact]
        public void ResetFlag_ToFail_WithBiggerIndexThanLength()
        {
            var flag = new MultipleBinaryFlag(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => flag.ResetFlag(12));
            Assert.Throws<ArgumentOutOfRangeException>(() => flag.ResetFlag(10));
        }

        [Fact]
        public void GetFlag()
        {
            var flag1 = new MultipleBinaryFlag(9);
            var flag2 = new MultipleBinaryFlag(9);

            flag2.ResetFlag(8);

            Assert.True(flag1.GetFlag());
            Assert.False(flag2.GetFlag());
        }

        [Fact]
        public void Dispose()
        {
            var flag = new MultipleBinaryFlag(9);

            flag.Dispose();

            Assert.Null(flag.ToString());
        }

        [Fact]
        public void SetFlag_AfterDispose()
        {
            var flag = new MultipleBinaryFlag(9);

            flag.Dispose();
            flag.SetFlag(4);
            flag.SetFlag(2);

            Assert.Null(flag.ToString());
        }

        [Fact]
        public void ResetFlag_AfterDispose()
        {
            var flag = new MultipleBinaryFlag(9);

            flag.Dispose();
            flag.ResetFlag(4);
            flag.ResetFlag(2);

            Assert.Null(flag.ToString());
        }

        [Fact]
        public void GetFlag_AfterDispose()
        {
            var flag = new MultipleBinaryFlag(9);

            flag.Dispose();

            Assert.Null(flag.GetFlag());
        }
    }
}