using System;
using Xunit;
using IIG.BinaryFlag;
using IIG.FileWorker;

namespace Lab4
{
    public class BinaryFlagAndFileWorkerTest
    {
        private const ulong minLength = 2;
        private const ulong maxLength = 17179868704;
        private const ulong length = 15;
        private const string filePath = "../file.out";
        private const ulong position = 1;

        [Fact]
        public void CreateFlag_DefaultValue()
        {
            var flag = new MultipleBinaryFlag(length);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_DefaultValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_DefaultValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_TrueValue()
        {
            var flag = new MultipleBinaryFlag(length, true);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_TrueValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength, true);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_TrueValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1, true);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_FalseValue()
        {
            var flag = new MultipleBinaryFlag(length, false);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_FalseValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength, false);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlag_FalseValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1, false);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_DefaultValue()
        {
            var flag = new MultipleBinaryFlag(length);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_DefaultValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_DefaultValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_DefaultValue_MaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength);
            flag.SetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void SetFlag_DefaultValue_LessThanMaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength - 1);
            flag.SetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void SetFlag_TrueValue()
        {
            var flag = new MultipleBinaryFlag(length, true);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_TrueValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength, true);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_TrueValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1, true);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_TrueValue_MaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength, true);
            flag.SetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void SetFlag_TrueValue_LessThanMaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength - 1, true);
            flag.SetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void SetFlag_FalseValue()
        {
            var flag = new MultipleBinaryFlag(length, false);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_FalseValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength, false);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_FalseValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1, false);
            flag.SetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlag_FalseValue_MaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength, false);
            flag.SetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void SetFlag_FalseValue_LessThanMaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength - 1, false);
            flag.SetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void ResetFlag_DefaultValue()
        {
            var flag = new MultipleBinaryFlag(length);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_DefaultValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_DefaultValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_DefaultValue_MaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength);
            flag.ResetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void ResetFlag_DefaultValue_LessThanMaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength - 1);
            flag.ResetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void ResetFlag_TrueValue()
        {
            var flag = new MultipleBinaryFlag(length, true);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_TrueValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength, true);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_TrueValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1, true);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_TrueValue_MaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength, true);
            flag.ResetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void ResetFlag_TrueValue_LessThanMaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength - 1, true);
            flag.ResetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void ResetFlag_FalseValue()
        {
            var flag = new MultipleBinaryFlag(length, false);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_FalseValue_MinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength, false);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_FalseValue_BiggerThanMinLenght()
        {
            var flag = new MultipleBinaryFlag(minLength + 1, false);
            flag.ResetFlag(position);

            var expected = flag.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetFlag_FalseValue_MaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength, false);
            flag.ResetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void ResetFlag_FalseValue_LessThanMaxLenght()
        {
            var flag = new MultipleBinaryFlag(maxLength - 1, false);
            flag.ResetFlag(position);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void GetFlag_DefaultValue()
        {
            var flag = new MultipleBinaryFlag(length);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }


        [Fact]
        public void GetFlag_TrueValue()
        {
            var flag = new MultipleBinaryFlag(length, true);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void GetFlag_FalseValue()
        {
            var flag = new MultipleBinaryFlag(length, false);

            var expectedBool = flag.GetFlag();
            var expected = expectedBool.ToString();
            var result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void DisposeFlag_DefaultValue()
        {
            var flag = new MultipleBinaryFlag(length);
            flag.Dispose();

            bool? expectedBool = flag.GetFlag();
            string expected = expectedBool.ToString();
            bool result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }


        [Fact]
        public void DisposeFlag_TrueValue()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(10, true);
            flag.Dispose();

            bool? expectedBool = flag.GetFlag();
            string expected = expectedBool.ToString();
            bool result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void DisposeFlag_FalseValue()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(length, false);
            flag.Dispose();

            bool? expectedBool = flag.GetFlag();
            string expected = expectedBool.ToString();
            bool result = BaseFileWorker.Write(expected, filePath);

            Assert.True(result);

            var actual = BaseFileWorker.ReadAll(filePath);
            var actualBool = Boolean.Parse(actual);

            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }
    }
}
