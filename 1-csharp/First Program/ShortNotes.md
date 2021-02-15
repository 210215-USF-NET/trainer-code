CLR (Common Language Runtime)

- Runtime that manages a bunch of stuff, garbage collection, etc.
- JIT (Just in time) compiler - Takes in code, transforms code into machine code that machine understands, the machine can run your code
  obj, bin folders
- build output
- result of running dotnet build
  dotnet run
- dotnet build + run the code
  dotnet build
- compiles code

TLDR compilation process:
.cs file > compiled using MSBUILD > IL (Intermediate Language) > CLR (common language runtime) processed by JIT > machine code
