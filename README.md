# FixFloat

This fixed float math library provides an efficient and deterministic solution for arithmetic and geometric operations in Unity projects. The library is designed to be compatible with Unity's Burst Compiler, ensuring high-performance and low-overhead when used in conjunction with Unity's job system.


## Features

- Fixed-point arithmetic using FixNumber for deterministic calculations

- 2D fixed-point vector operations with FixVec

- Trigonometric functions using fixed-point angles

- Rotation matrix support with RotationMatrix

- Angle conversion and manipulation utilities in FixAngle

- Unity and Burst Compiler compatible


## Installation

To use iShape.FixFloat in your Unity project, follow these steps:

- Open your Unity project.
- In the top menu, select "Window" > "Package Manager".
- Click on the "+" button in the top-left corner of the Package Manager window.
- Select "Add package from git URL...".
- Enter the following URL: https://github.com/iShapeUnity/FixFloat.git
- Click the "Add" button.
- Wait for the package to be imported.
- In your C# scripts, add the following using statement to access the library:

```csharp
using iShape.FixFloat;
```


## How It Works

The \`**FixNumber**\` class uses fixed-point arithmetic to perform calculations with a high degree of precision and determinism. It supports numbers in the range 2^21 - 1 to -2^21 + 1 with a precision of 1/1024, and is most suitable for the range 10,000,000 to -10,000,000 with a precision of 0.01.

Fixed-point numbers are represented using a fixed number of bits for the fractional part. In this implementation, the number of bits representing the fractional part of the fixed-point number is 10, which allows for a precision of 1/1024 or approximately 0.001.

Here are some examples of fixed-point number representation:

- 1 / 1024 ≈ 0.001 (represented as 1)
- 256 / 1024 = 0.25 (represented as 256)
- 1024 / 1024 = 1 (represented as 1024)
- (1024 + 512) / 1024 = 1.5 (represented as 1536)
- (2048 + 256) / 1024 = 2.25 (represented as 2304)

By using the \`**FixNumber**\` class, you can perform arithmetic operations using long values while maintaining the precision of floating-point numbers, ensuring deterministic behavior across different platforms and devices.


## Usage

### FixNumber

The \`**FixNumber**\` class represents a fixed-point number using a \`**long**\` as the underlying storage, allowing deterministic arithmetic operations. Use \`**FixNumber**\` for calculations instead of \`**float**\` or \`**double**\` when deterministic behavior is required. \`**FixNumber**\` provides a way to perform arithmetic operations with \`**long**\` values while maintaining the precision of floating-point numbers.

```csharp
long a = 3.14f.ToFix();
long b = 2.0f.ToFix();
long result = a * b;
float resultAsFloat = result.ToFloat();
```

### FixVec

The \`**FixVec**\` struct represents a 2D fixed-point vector, providing various utility methods and operators for vector operations. Use \`**FixVec**\` for 2D geometric calculations when deterministic behavior is required.

```csharp
FixVec vec1 = new FixVec(1.0f.ToFix(), 2.0f.ToFix());
FixVec vec2 = new FixVec(3.0f.ToFix(), 4.0f.ToFix());

FixVec sum = vec1 + vec2;
FixVec difference = vec1 - vec2;
```

### FixAngle
The \`**FixAngle**\` class provides various utility methods for working with fixed-point angles, including trigonometric functions and angle conversion.


```csharp
long angle = (Mathf.PI / 2).ToFix().RadToFixAngle();
long sin = angle.Sin();
long cos = angle.Cos();
```


## Compatibility

This library is designed to be compatible with Unity and the Burst Compiler, enabling high-performance arithmetic and geometric operations in Unity projects that utilize the job system and Burst.


## License

This Fixed Float Math Library is released under the [MIT license](https://en.wikipedia.org/wiki/MIT_License).


