let computers = [];
let jobs = [];
let people = [];

//non-crud objects

//API
//#region API
async function getComputers() {
    await fetch('http://localhost:59537/Computer/')
        .then(response => response.json())
        .then(data => {
            computers = data;
            console.log("Computers GET done");
        });
}
async function getJobs() {
    await fetch('http://localhost:59537/Job/')
        .then(response => response.json())
        .then(data => {
            jobs = data;
            console.log("Jobs GET done");
        });
}
async function getPeople() {
    await fetch('http://localhost:59537/Person/')
        .then(response => response.json())
        .then(data => {
            people = data;
            console.log("People GET done");
        });
}

// non-crud methods

//#endregion

//signalR
//#region signalR
let connection = null;

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:59537/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ComputerCreated", (user, message) => {
        return getComputers()
            .then(() => displayComputers());
    });
    connection.on("ComputerDeleted", (user, message) => {
        return getComputers()
            .then(() => displayComputers());
    });
    connection.on("ComputerUpdated", (user, message) => {
        return getComputers()
            .then(() => displayComputers());
    });

    connection.on("JobCreated", (user, message) => {
        return getJobs()
            .then(() => displayJobs());
    });
    connection.on("JobDeleted", (user, message) => {
        return getJobs()
            .then(() => displayJobs());
    });
    connection.on("JobUpdated", (user, message) => {
        return getJobs()
            .then(() => displayJobs());
    });

    connection.on("PeopleCreated", (user, message) => {
        return getPeople()
            .then(() => displayPeople());
    });
    connection.on("PeopleDeleted", (user, message) => {
        return getPeople()
            .then(() => displayPeople());
    });
    connection.on("PeopleUpdated", (user, message) => {
        return getPeople()
            .then(() => displayPeople());
    });

    connection.onclose
        (async () => {
            await start();
        });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected!");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
//#endregion

//Computers
//#region Computers
let computerIdUpdate = 0;
function displayComputers() {
    document.getElementById('computerwindow').style.display = 'flex';
    document.getElementById('jobwindow').style.display = 'none';
    document.getElementById('personwindow').style.display = 'none';
    document.getElementById('updateComputer').style.display = 'none';
    document.getElementById('updateJob').style.display = 'none';
    document.getElementById('updatePerson').style.display = 'none';

    return getComputers().then(() => {

        document.getElementById('computers').innerHTML = "";
        computers.forEach(t => {
            document.getElementById('computers').innerHTML +=
                `<tr><td><input type="radio" name="selectComputerRadio" onclick='showUpdateComputer("${t.computerID}","${t.gpuManufacturer}","${t.gpuModel}")'></input></td>` +
                "</td><td>" + t.gpuManufacturer +
                "</td><td>" + t.gpuModel +
                `</td><td><button type="button" onclick='removeComputer(${t.computerID})'>Delete</button></td></tr>`;
        })
    });
}
function addComputer() {
    let gpuManufacturer = document.getElementById('gpuManufacturer').value;
    let gpuModel = document.getElementById('gpuModel').value;

    fetch('http://localhost:59537/Computer/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            gpuManufacturer: gpuManufacturer,
            gpuModel: gpuModel
        })
    })
        .then(data => {
            console.log(data);
            displayComputers();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
async function removeComputer(id) {
    await fetch('http://localhost:59537/Computer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            return getComputers();
        }).then(() => displayComputers())
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showUpdateComputer(id, gpuManufacturer, gpuModel) {
    document.getElementById('updateComputer').style.display = 'flex';
    document.getElementById('gpuManufacturerUpdate').value = gpuManufacturer;
    document.getElementById('gpuModelUpdate').value = gpuModel;
    computerIdUpdate = id;
}
function updateComputer() {
    let gpuManufacturer = document.getElementById('gpuManufacturerUpdate').value;
    let gpuModel = document.getElementById('gpuModelUpdate').value;

    fetch('http://localhost:59537/Computer/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            computerID: computerIdUpdate,
            gpuManufacturer: gpuManufacturer,
            gpuModel: gpuModel
        })
    })
        .then(data => {
            console.log(data);
            return getComputers();
        })
        .then(() => {
            displayComputers();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    document.getElementById('updateComputer').style.display = 'none';
}
//#endregion

//Jobs
//#region Jobs
let jobIdUpdate = 0;
function displayJobs() {
    document.getElementById('computerwindow').style.display = 'none';
    document.getElementById('jobwindow').style.display = 'flex';
    document.getElementById('personwindow').style.display = 'none';
    document.getElementById('updateComputer').style.display = 'none';
    document.getElementById('updateJob').style.display = 'none';
    document.getElementById('updatePerson').style.display = 'none';

    return getJobs().then(() => {
        document.getElementById('jobs').innerHTML = "";
        jobs.forEach(t => {
            document.getElementById('jobs').innerHTML +=
                `<tr><td><input type="radio" name="selectJobRadio" onclick='showUpdateJob("${t.jobID}","${t.jobName}","${t.salary}")'></input></td>` +
                "</td><td>" + t.jobName +
                "</td><td>" + t.salary +
                `</td><td><button type="button" onclick='removeJob(${t.jobID})'>Delete</button></td></tr>`;
        });
    });
}

function addJob() {
    let jobName = document.getElementById('jobName').value;
    let salary = document.getElementById('salary').value;

    fetch('http://localhost:59537/Job/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            jobName: jobName,
            salary: salary
        })
    })
        .then(data => {
            console.log(data);
            displayJobs();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
async function removeJob(id) {
    await fetch('http://localhost:59537/Job/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            return getJobs();
        }).then(() => displayJobs())
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showUpdateJob(id, jobName, salary) {
    document.getElementById('updateJob').style.display = 'flex';
    document.getElementById('jobNameUpdate').value = jobName;
    document.getElementById('salaryUpdate').value = salary;
    jobIdUpdate = id;
}
function updateJob() {
    let jobName = document.getElementById('jobNameUpdate').value;
    let salary = document.getElementById('salaryUpdate').value;

    fetch('http://localhost:59537/Job/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            jobID: jobIdUpdate,
            jobName: jobName,
            salary: salary
        })
    })
        .then(data => {
            console.log(data);
            return getJobs();
        })
        .then(() => {
            displayJobs();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    document.getElementById('updateJob').style.display = 'none';
}
//#endregion

//People
//#region People
let peopleIdUpdate = 0;
function displayPeople() {
    document.getElementById('computerwindow').style.display = 'none';
    document.getElementById('jobwindow').style.display = 'none';
    document.getElementById('personwindow').style.display = 'flex';
    document.getElementById('updateComputer').style.display = 'none';
    document.getElementById('updateJob').style.display = 'none';
    document.getElementById('updatePerson').style.display = 'none';

    return getPeople().then(() => {

        document.getElementById('people').innerHTML = "";
        people.forEach(t => {
            document.getElementById('people').innerHTML +=
                `<tr><td><input type="radio" name="selectPersonRadio" onclick='showUpdatePerson("${t.personID}","${t.name}","${t.age}")'></input></td>` +
                "</td><td>" + t.name +
                "</td><td>" + t.age +
                `</td><td><button type="button" onclick='removePerson(${t.personID})'>Delete</button></td></tr>`;;
        })
    });
}
function addPerson() {
    let name = document.getElementById('name').value;
    let age = document.getElementById('age').value;

    fetch('http://localhost:59537/Person/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name: name,
            age: age
        })
    })
        .then(data => {
            console.log(data);
            displayPeople();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

async function removePerson(id) {
    await fetch('http://localhost:59537/Person/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            return getPeople();
        }).then(() => displayPeople())
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showUpdatePerson(id, name, age) {
    document.getElementById('updatePerson').style.display = 'flex';
    document.getElementById('nameUpdate').value = name;
    document.getElementById('ageUpdate').value = age;
    personIdUpdate = id;
}
function updatePerson() {
    let name = document.getElementById('nameUpdate').value;
    let age = document.getElementById('ageUpdate').value;

    fetch('http://localhost:59537/Person/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            personID: personIdUpdate,
            name: name,
            age: age
        })
    })
        .then(data => {
            console.log(data);
            return getPeople();
        })
        .then(() => {
            displayPeople();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    document.getElementById('updatePerson').style.display = 'none';
}
//#endregion