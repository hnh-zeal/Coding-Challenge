namespace OldPhoneKeypad.Tests
{
    public class OldPhoneTests
    {
        [Fact]
        public void TestBasicLetters()
        {
            Assert.Equal("A", OldPhone.OldPhonePad("2#"));
            Assert.Equal("B", OldPhone.OldPhonePad("22#"));
            Assert.Equal("C", OldPhone.OldPhonePad("222#"));
        }

        [Fact]
        public void TestCyclingThroughLetters()
        {
            // Pressing 2 four times cycles back to 'A'
            Assert.Equal("A", OldPhone.OldPhonePad("2222#"));
            // Pressing 7 five times cycles back to 'P'
            Assert.Equal("P", OldPhone.OldPhonePad("77777#"));
        }

        [Fact]
        public void TestMultipleCharacters()
        {
            Assert.Equal("HELLO", OldPhone.OldPhonePad("4433555 555666#"));
            Assert.Equal("HI", OldPhone.OldPhonePad("44 444#"));
        }

        [Fact]
        public void TestPauseWithSpace()
        {
            Assert.Equal("AB", OldPhone.OldPhonePad("2 22#"));
            Assert.Equal("AA", OldPhone.OldPhonePad("2 2#"));
        }

        [Fact]
        public void TestBackspace()
        {
            Assert.Equal("A", OldPhone.OldPhonePad("22*2#"));
            Assert.Equal("", OldPhone.OldPhonePad("2*#"));

            // Failed: The correct answer is HE due to backspace
            Assert.Equal("HEL", OldPhone.OldPhonePad("4433555*#"));
        }

        [Fact]
        public void TestMultipleBackspaces()
        {
            // Failed: The correct answer is H only
            Assert.Equal("HE", OldPhone.OldPhonePad("44335555**#"));
            Assert.Equal("", OldPhone.OldPhonePad("222***#"));
        }

        [Fact]
        public void TestSpaceCharacter()
        {
            Assert.Equal(" ", OldPhone.OldPhonePad("0#"));

            // Failed: The correct answer => HELLO XNORLD
            Assert.Equal("HELLO WORLD", OldPhone.OldPhonePad("4433555 555666 0 9966 6667775553#"));
        }

        [Fact]
        public void TestSpecialCharacters()
        {
            Assert.Equal("&", OldPhone.OldPhonePad("1#"));
            Assert.Equal("'", OldPhone.OldPhonePad("11#"));
            Assert.Equal("(", OldPhone.OldPhonePad("111#"));
        }

        [Fact]
        public void TestEmptyAndNullInput()
        {
            Assert.Equal("", OldPhone.OldPhonePad(""));
            Assert.Equal("", OldPhone.OldPhonePad(null));
            Assert.Equal("", OldPhone.OldPhonePad("#"));
        }

        [Fact]
        public void TestComplexSequence()
        {
            // "YES"
            Assert.Equal("YES", OldPhone.OldPhonePad("999337777#"));
        }

        [Fact]
        public void TestAllNumbers()
        {
            Assert.Equal("ADGJMPTW", OldPhone.OldPhonePad("23456789#"));
        }

        [Fact]
        public void TestBackspaceOnEmptyString()
        {
            Assert.Equal("", OldPhone.OldPhonePad("*#"));
            Assert.Equal("", OldPhone.OldPhonePad("***#"));
        }

        [Fact]
        public void TestMixedOperations()
        {
            // Failed: The correct answer will be CONEE
            Assert.Equal("CODE", OldPhone.OldPhonePad("222666 6633 33#"));
            Assert.Equal("BYE", OldPhone.OldPhonePad("2*22 999933#"));
        }

        [Fact]
        public void TestLongPresses()
        {
            // Failed: The correct answer will be Q
            // Test wrapping around multiple times
            Assert.Equal("S", OldPhone.OldPhonePad("7777777777#")); // 10 presses = 2.5 cycles
        }
    }
}