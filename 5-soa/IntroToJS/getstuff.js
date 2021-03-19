function GetPokemon()
{
    //Creating the object that sends the request and receives the response from the pokeapi
    let xhr = new XMLHttpRequest();
    //Creating the object that holds the response data
    let pokemon = {};
    //Creating the variable that holds the id/name of the pokemon i wanna find
    let pokemon2Search = document.querySelector('#pokemon2Search').value;

    //the onreadystate just describes the state of your request 
    // 0 - uninitialized
    // 1 - loading (server connection established) the open method has been invoked
    // 2 - loaded (request received by server) send has been called
    // 3 - interactive (processing request) response body is being received
    // 4 - complete (response received) 
    xhr.onreadystatechange = function () {
        // checks if response has been received and if the operation was successful by checking if the status
        // codes are within the 2xxs
        if (this.readyState == 4 && this.status > 199 && this.status < 300)
        {
            //deserializing the json response body of the httpresponse
            pokemon = JSON.parse(xhr.responseText);
            //using combinator selectors I'm getting the img element that belongs to a tag with class pokemonResult
            document.querySelector('.pokemonResult img').setAttribute('src', pokemon.sprites.front_default);
            //clean out previous captions, gets all child captions of the tag that belongs to the class pokemonResult
            // foreach child, remove them 
            document.querySelectorAll('.pokemonResult caption').forEach((element) => element.remove());
            // creates a caption element
            // <caption> </caption>
            let caption = document.createElement('caption');
            // create a text node to add as value of caption element
            // floating pokemonName
            let pokemonName = document.createTextNode(pokemon.forms[0].name);
            //Because the caption would contain the text node
             // <caption> pokemonName </caption>
            caption.appendChild(pokemonName);
            //this is where you append the caption element you just created to the DOM of the page
            document.querySelector('.pokemonResult').appendChild(caption);
            document.querySelector('#pokemon2Search').value = '';
        }
    }
    //assemble your httprequest
    // first param is the httpverb, second is the url, last is if you want to execute it async 
    xhr.open("GET", `https://pokeapi.co/api/v2/pokemon/${pokemon2Search}`, true);
    //send the request
    xhr.send();

}
function GetDigimon()
{
    let digimon2Search = document.querySelector('#digimon2Search').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digimon2Search}`)
        .then(result => result.json())
        .then(digimon => {
            document.querySelector('.digimonResult img').setAttribute('src', digimon[0].img);
            document.querySelectorAll('.digimonResult cpation').forEach(caption => caption.remove());
            let caption = document.createElement('caption');
            caption.appendChild(document.createTextNode(digimon[0].name));
            document.querySelector('.digimonResult').appendChild(caption);
            document.querySelector('#digimon2Search').value = '';
        });
}