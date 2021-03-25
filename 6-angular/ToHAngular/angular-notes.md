# Angular

Front end fw used to create SPAs. (SPAs are Single Page Applications.) Modularized in nature, front end design revolves around the idea of components making up a page.

## SPAs

Single Page Applications as you've guessed are web apps that are contained in a single page. It means that, when you access that webapp for the first time, you are served a page from the server, and any other interaction with that page, JS takes care of and manipulates the page via the DOM. You have the illusion of interacting with different pages, but its really the same page being rewritten over and over again.

### Advantages of SPAs

1. No more server roundtrips!
2. Your page will always be responsive, it doesn't freeze up as whole.
3. Super easy to deploy in Prod and even to version over time!

### Disadvantages

1. With Angular, the startup load time of your SPA takes a while. This is because when you query the server for the first time, you are given everything.
2. Learning pains.

## Architecture

### Modules

Containers for a cohesive block of code dedicated to an application domain, a workflow, or a closely related set of capabilities. In a nutshell: its a way to encapsulate code/logic that go together. Modules in Angular are based on modules in es6, but they have metadata. The `@NgModule` metadata plays an important role in guiding the Angular compilation process that converts the app code you write into highly performant JavaScript code. [Read more about it](https://angular.io/guide/ngmodule-vs-jsmodule). To declare a module, you use the @NgModule decorator.

### Components

Views with logic. When scaffolding a component, the ng cli gives you 4 files:

1. css file (styling)
2. html file (template)
3. ts file (logic)
4. spec.ts file (unit testing)

In actuality, a component needs only 2 files:

1. html file
2. ts file

Because in essence, a component is just a view with logic. How do you define a class as a component? You use the @component decorator.

### Templates

This just the html file. This defines the structure of your component. What does it look like? How do you arrange the data?

### Services

Logic that is shared between components or other services. Your components should have the view specific logic to them, any logic that is shared or not related to the view, you store in services. Sort of your BL if components are views. Services have the @Injectable decorator that allows them to be injected as deps in components or other services.

### Decorators

Used to distinguish the functionality of your classes. Like @NgModule, declares a class as a module.
[List of decorators in Angular](https://medium.com/@madhavmahesh/list-of-all-decorators-available-in-angular-71bdf4ad6976)
