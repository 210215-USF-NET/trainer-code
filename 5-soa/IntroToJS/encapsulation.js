// This IIFE uses the outer function's count parameter
let Outer = (() => {
    // "private" variable we'll be manipulating
    let count = 0;
    return function inner() {
        return count += 1;
    }
})();

let addMore = (() => {
    let count = 0;
    return () => {
        return count += 1;
    }
});

let add = addMore();
let addAgain = addMore();