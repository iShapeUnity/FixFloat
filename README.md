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

## Usage

### FixNumber

The \`**FixNumber**\` class represents a fixed-point number using a \`**long**\` as the underlying storage, allowing deterministic arithmetic operations. Use \`**FixNumber**\` for calculations instead of \`**float**\` or \`**double**\` when deterministic behavior is required. \`**FixNumber**\` provides a way to perform arithmetic operations with \`**long**\` values while maintaining the precision of floating-point numbers.
