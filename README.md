# Item Dependency and Ordering in C#

This is a C# program that will read a list of items and their dependencies to output a list of items in the order that they can be safely processed.

## Installation

To install this program, you will need to have DotNet Core 6.0 installed on your system. You can download DotNet Core 6.0 from [here](https://dotnet.microsoft.com/download/dotnet/6.0).

Once you have DotNet Core 6.0 installed, you can clone this repository to your local system. Then you can compile the program by running the following command from the root of the repository:

```
dotnet build
```

You can execute the program by running the following command from the root of the repository:

```
dotnet run
```

## Testing

I was unable to get unit testing working in C# using VS Code on my Mac. I tried Xunit and Nunit in both dotnet 6 and dotnet 7 to no avail. There is a dependency missing from the full Visual Studio IDE that is not included in VS Code. Visual Studio is a beast and I would rather not have that installed to my personal Mac right now.

The following command fails on my Mac in VS Code.

```
dotnet test
```

## Requirements

The exact requirements given to me are as follows:

```
create a javascript function that solves the following dependency problem:

A person needs to figure out which order his/her clothes need to be put on.

The person creates a file that contains the dependencies.

This input is a declared array of dependencies with the [0] index being the dependency and the [1] index being the item.

A simple input would be:

var input = new string[,]
{
  //dependency    //item
  { "t-shirt", "dress shirt" },
  { "dress shirt", "pants" },
  { "dress shirt", "suit jacket" },
  { "tie", "suit jacket" },
  { "pants", "suit jacket" },
  { "belt", "suit jacket" },
  { "suit jacket", "overcoat" },
  { "dress shirt", "tie" },
  { "suit jacket", "sun glasses" },
  { "sun glasses", "overcoat" },
  { "left sock", "pants" },
  { "pants", "belt" },
  { "suit jacket", "left shoe" },
  { "suit jacket", "right shoe" },
  { "left shoe", "overcoat" },
  { "right sock", "pants" },
  { "right shoe", "overcoat" },
  { "t-shirt", "suit jacket" }
};


In this example, it shows that they must put on their left sock before their pants. Also, they must put on their pants before their belt.

From this data, write a program that provides the order that each object needs to be put on.

The output should be a line-delimited list of objects. If there are multiple objects that can be done at the same time, list each object on the same line, alphabetically sorted, comma separated.

Therefore, the output for this sample file would be:

 left sock,right sock, t-shirt

dress shirt

pants, tie

belt

suit jacket

left shoe, right shoe, sun glasses

overcoat
```
