import { hero } from "./models/hero";

// note that when declaring stuff, you assign it a type
function GetAllHeroes(): void {
    fetch("https://localhost:5001/api/hero")
        .then(response => response.json())
        .then(responseBody => PrintHeroesTable(responseBody));
}
function PrintHeroesTable(heroes: hero[]): void {
    document.querySelectorAll('#heroes tbody tr').forEach(row => row.remove());
    //using the union to set the table element to either be of type HTMLTableElement (which is an interface) or null
    let table: HTMLTableElement | null = document.querySelector<HTMLTableElement>('#heroes tbody');
    //leveraging the truthiness of the table value
    if (table) {
        //for each hero from the server, add a row to the table
        for (let i: number = 0; i < heroes.length; ++i) {
            //inserting a row at the bottom of a table
            let row: HTMLTableRowElement = table.insertRow(table.rows.length);

            //inserting a data cell of index 0 at the row
            let heroNameCell: HTMLTableCellElement = row.insertCell(0);
            //setting the data of that cell to be the current hero's name
            heroNameCell.innerHTML = heroes[i].heroName;

            let hpCell: HTMLTableCellElement = row.insertCell(1);
            hpCell.innerHTML = heroes[i].hp.toString();

            let elementCell: HTMLTableCellElement = row.insertCell(2);
            elementCell.innerHTML = heroes[i].elementType.toString();

            let spNameCell: HTMLTableCellElement = row.insertCell(3);
            spNameCell.innerHTML = heroes[i].superPower.name;

            let spDescCell: HTMLTableCellElement = row.insertCell(4);
            spDescCell.innerHTML = heroes[i].superPower.description;

            let spDmgCell: HTMLTableCellElement = row.insertCell(5);
            spDmgCell.innerHTML = heroes[i].superPower.damage.toString();

        }
    }

}
function AddAHero(): void {
    let hero2Add: hero = {
        heroName: document.querySelector<HTMLInputElement>('#heroName')!.value,
        hp: parseInt(document.querySelector<HTMLInputElement>('#hp')!.value),
        elementType: parseInt(document.querySelector<HTMLSelectElement>('#elementType')!.value),
        superPower:
        {
            name: document.querySelector<HTMLInputElement>('#superPowerName')!.value,
            description: document.querySelector<HTMLInputElement>('#superPowerDesc')!.value,
            damage: parseInt(document.querySelector<HTMLInputElement>('#superPowerDmg')!.value)
        }
    }
    let xhr: XMLHttpRequest = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status > 199 && this.status < 300) {
            console.log("a hero has been added");
            document.querySelector<HTMLInputElement>('#heroName')!.value = '';
            document.querySelector<HTMLInputElement>('#hp')!.value = '';
            document.querySelector<HTMLSelectElement>('#elementType')!.value = '';
            document.querySelector<HTMLInputElement>('#superPowerName')!.value = '';
            document.querySelector<HTMLInputElement>('#superPowerDesc')!.value = '';
            document.querySelector<HTMLInputElement>('#superPowerDmg')!.value = '';
            GetAllHeroes();
        }
    }
    xhr.open("POST", "https://localhost:5001/api/hero", true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(hero2Add));
}