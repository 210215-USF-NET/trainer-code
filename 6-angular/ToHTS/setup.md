# Getting Started with TypeScript (TS)

## Get node installed in your machine

Use the link [node dl place](https://nodejs.org/en/) and get the stable version of node.

### What is node.js

- Interpreter/server environment for JS, so you'll be able to run JS scripts outside of the browser
- Comes with an engine that runs your scripts
- And NPM (the node package manager) to manage the packages and dependencies that you need in your JS project

#### Note: To check if node is properly installed, run the command `node -v` on your cmd line (I recommend bash)

## Creating a TS project

1. Create a folder to store your project
2. Navigate into the folder and create a package.json file using the command `npm init -y`
   - a package.json file holds various metadata relevant to the project. Used to give information to your package manager that allows it to identify the project, as well as handle the projects deps
3. Run the command `npm i typescript -g` to install the relevant deps/tools you'll need working with ts globally
   - this is important because we wanna develop with ts
   - change the `-g` to `--save-dev` if you wanna install ts locally
4. In the package.json file, configure the node script to compile with tsc.
   - Include “scripts”:{ “tsc”: “tsc”}. “scripts” should already be among the key:value pairs.
   - Running `tsc` locally will compile the closest project defined by a tsconfig.json, you can compile a set of TypeScript files by passing in a glob of files you want.
   - `tsc` is the TypeScript compiler and has a command line interface with sufficient available options.
   - tldr; cmd that you use to compile your ts project
5. Run the command `tsc --init` to scaffold a tsconfig.json file
   - this initializes a ts project
   - the tsconfig.json file specifies the root files and the compiler options required to compile the project
   - make sure to edit your tsconfig to include a place to put the transpiled js in another folder and to add in where the compiler will look for things to compile
6. Write your first .ts file!
   - really like js but with types
   - so in ts, the syntax is `name: type`
