# Old Phone Keypad Simulator

A C# implementation of a classic T9-style phone keypad text input system, where multiple presses of number keys produce different letters.

## Problem Description

This project simulates the old mobile phone keypad input method where you had to press number keys multiple times to type letters. For example, pressing `2` once gives 'A', twice gives 'B', and three times gives 'C'.

## Features

- **Multi-press input**: Press the same key multiple times to cycle through available characters
- **Pause mechanism**: Use space to commit the current character and start a new one
- **Backspace**: Use `*` to delete the last character
- **Terminator**: Use `#` to finalize and return the input string
- **Wrapping**: Continues cycling if you press a key more times than it has characters

## Keypad Mapping

```
0 → " " (space)
1 → &'(
2 → ABC
3 → DEF
4 → GHI
5 → JKL
6 → MNO
7 → PQRS
8 → TUV
9 → WXYZ
* → Backspace
# → Submit/End input
```

## Installation

### Prerequisites
- .NET 6.0 or higher
- xUnit (for running tests)

### Setup
```bash
# Clone the repository
git clone https://github.com/yourusername/old-phone-keypad.git

# Navigate to the project directory
cd old-phone-keypad

# Restore dependencies
dotnet restore

# Build the project
dotnet build
```

## Usage

```csharp
using OldPhoneKeypad;

// Basic usage
string result = OldPhone.OldPhonePad("4433555 555666#");
// Output: "HELLO"

// With backspace
string result2 = OldPhone.OldPhonePad("44335555**#");
// Output: "HE"

// With special characters
string result3 = OldPhone.OldPhonePad("4433555 555666 0 9966 6667775553#");
// Output: "HELLO WORLD"
```

## Examples

| Input | Output | Explanation |
|-------|--------|-------------|
| `2#` | A | Press 2 once |
| `22#` | B | Press 2 twice |
| `222#` | C | Press 2 three times |
| `2222#` | A | Wraps around after C |
| `2 22#` | AB | Space pauses and commits 'A', then starts 'B' |
| `22*2#` | A | Backspace removes 'B', then adds 'A' |
| `4433555 555666#` | HELLO | Full word with pauses |
| `0#` | (space) | Zero key produces a space |

## Running Tests

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run tests with coverage (requires coverlet)
dotnet test /p:CollectCoverage=true
```

## Test Coverage

The test suite includes:
- ✅ Basic single letter inputs
- ✅ Cycling through letters on the same key
- ✅ Multiple character sequences
- ✅ Pause functionality with spaces
- ✅ Backspace operations
- ✅ Multiple backspaces
- ✅ Space character input
- ✅ Special characters (from key 1)
- ✅ Empty and null input handling
- ✅ Complex sequences
- ✅ Edge cases and wrapping behavior

## Algorithm Explanation

The solution uses a state machine approach:

1. **State tracking**: Maintains `lastKey` and `pressCount` to track the current input sequence
2. **Character commitment**: When switching keys, a pause, or backspace occurs, the accumulated presses are converted to the appropriate character
3. **Modulo wrapping**: Uses `(pressCount - 1) % letters.Length` to cycle through characters
4. **StringBuilder optimization**: Uses `StringBuilder` for efficient string concatenation in C#

### Time Complexity
- O(n) where n is the length of the input string

### Space Complexity
- O(m) where m is the length of the output string

## Project Structure

```
OldPhoneKeypad/
├── OldPhone.cs           # Main implementation
├── OldPhoneTests.cs      # Unit tests
├── README.md             # This file
└── OldPhoneKeypad.csproj # Project file
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Author

[Your Name]

## Acknowledgments

- Inspired by classic T9 mobile phone input systems
- Built as a coding challenge solution
