let computers = [];
//let jobs = [];
//let people = [];

//non-crud objects

//API
//#region API
async function getComputers() {
    await fetch('http://localhost:59537/Computer')
        .then(response => response.json())
        .then(data => {
            computers = data;
            console.log("Computers GET done");
        });
}
//async function getJobs() {
//    await fetch('http://localhost:59537/Job')
//        .then(response => response.json())
//        .then(data => {
//            jobs = data;
//            console.log("Jobs GET done");
//        });
//}
//async function getPeople() {
//    await fetch('http://localhost:59537/Person')
//        .then(response => response.json())
//        .then(data => {
//            people = data;
//            console.log("People GET done");
//        });
//}

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

    //connection.on("JobCreated", (user, message) => {
    //    return getJobs()
    //        .then(() => displayJobs());
    //});
    //connection.on("JobDeleted", (user, message) => {
    //    return getJobs()
    //        .then(() => displayJobs());
    //});
    //connection.on("JobUpdated", (user, message) => {
    //    return getJobs()
    //        .then(() => displayJobs());
    //});

    //connection.on("PeopleCreated", (user, message) => {
    //    return getPeople()
    //        .then(() => displayPeople());
    //});
    //connection.on("PeopleDeleted", (user, message) => {
    //    return getPeople()
    //        .then(() => displayPeople());
    //});
    //connection.on("PeopleUpdated", (user, message) => {
    //    return getPeople()
    //        .then(() => displayPeople());
    //});

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

//Customers
//#region Computers
let computerIdUpdate = 0;
function displayComputers() {
    document.getElementById('computerwindow').style.display = 'flex';
    //document.getElementById('jobwindow').style.display = 'none';
    //document.getElementById('personwindow').style.display = 'flex';

    document.getElementById('updateComputer').style.display = 'none';
    //document.getElementById('updateJob').style.display = 'none';
    //document.getElementById('updatePerson').style.display = 'none';

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

    fetch('http://localhost:59537/Computer', {
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

    fetch('http://localhost:59537/Computer', {
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

////Bookings
////#region Bookings
//let bookingIdUpdate = 0;
//async function displayBookings() {
//    document.getElementById('bookingwindow').style.display = 'flex';
//    document.getElementById('pooltablewindow').style.display = 'none';
//    document.getElementById('customerwindow').style.display = 'none';
//    document.getElementById('updateCustomer').style.display = 'none';
//    document.getElementById('updateBooking').style.display = 'none';
//    document.getElementById('updatePoolTable').style.display = 'none';

//    await Promise.all([getCustomers(), getPoolTables(), getBookings(), getMostUsedTable()]);

//    document.getElementById('bookings').innerHTML = "";
//    bookings.forEach(t => {
//        document.getElementById('bookings').innerHTML +=
//            `<tr><td><input type="radio" name="selectBookingRadio" onclick='showUpdateBooking("${t.bookingId}","${t.startDate}","${t.endDate}","${t.customer.customerId}","${t.poolTable.tableId}")'></input></td>` +
//            "</td><td>" + t.customer.name +
//            "</td><td>" + formatDate(t.startDate) +
//            "</td><td>" + formatDate(t.endDate) +
//            "</td><td>" + t.poolTable.t_kind + " - " + t.poolTable.tableId + "" +
//            `</td><td><button type="button" onclick='removeBooking(${t.bookingId})'>Delete</button></td></tr>`;;
//    })

//    document.getElementById('customerSelect').innerHTML = "";
//    document.getElementById('customerSelectUpdate').innerHTML = "";
//    customers.forEach(c => {

//        document.getElementById('customerSelect').innerHTML +=
//            "<option value='" + c.customerId + "'>" + c.name + "</option>";

//        document.getElementById('customerSelectUpdate').innerHTML +=
//            "<option value='" + c.customerId + "'>" + c.name + "</option>";
//    })

//    document.getElementById('poolTableSelect').innerHTML = "";
//    document.getElementById('poolTableSelectUpdate').innerHTML = "";
//    pooltables.forEach(t => {
//        document.getElementById('poolTableSelect').innerHTML +=
//            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
//        document.getElementById('poolTableSelectUpdate').innerHTML +=
//            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
//    })
//    document.getElementById('mostUsedTable').value = mostUsedTable[0].t_kind + ' - ' + mostUsedTable[0].tableId;
//}
//async function displayBookingsBetweenDates() {
//    document.getElementById('bookingwindow').style.display = 'flex';
//    document.getElementById('pooltablewindow').style.display = 'none';
//    document.getElementById('customerwindow').style.display = 'none';
//    document.getElementById('updateCustomer').style.display = 'none';
//    document.getElementById('updateBooking').style.display = 'none';
//    document.getElementById('updatePoolTable').style.display = 'none';

//    let start = document.getElementById('queryStart').value;
//    let end = document.getElementById('queryEnd').value;

//    await Promise.all([getBookingsBetweenTwoDates(start, end), getPoolTables(), getCustomers(), getHowManyBookingsBetweenTwoDates(start, end)]);

//    document.getElementById('bookings').innerHTML = "";
//    bookings.forEach(t => {
//        document.getElementById('bookings').innerHTML +=
//            `<tr><td><input type="radio" name="selectBookingRadio" onclick='showUpdateBooking("${t.bookingId}","${t.startDate}","${t.endDate}","${t.customer.customerId}","${t.poolTable.tableId}")'></input></td>` +
//            "</td><td>" + t.customer.name +
//            "</td><td>" + formatDate(t.startDate) +
//            "</td><td>" + formatDate(t.endDate) +
//            "</td><td>" + t.poolTable.t_kind + " - " + t.poolTable.tableId + "" +
//            `</td><td><button type="button" onclick='removeBooking(${t.bookingId})'>Delete</button></td></tr>`;;
//    })

//    document.getElementById('customerSelect').innerHTML = "";
//    document.getElementById('customerSelectUpdate').innerHTML = "";
//    customers.forEach(c => {

//        document.getElementById('customerSelect').innerHTML +=
//            "<option value='" + c.customerId + "'>" + c.name + "</option>";

//        document.getElementById('customerSelectUpdate').innerHTML +=
//            "<option value='" + c.customerId + "'>" + c.name + "</option>";
//    })

//    document.getElementById('poolTableSelect').innerHTML = "";
//    document.getElementById('poolTableSelectUpdate').innerHTML = "";
//    pooltables.forEach(t => {
//        document.getElementById('poolTableSelect').innerHTML +=
//            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
//        document.getElementById('poolTableSelectUpdate').innerHTML +=
//            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
//    })

//    document.getElementById('countBookings').value = numberOfBookings;
//}
//function addBooking() {
//    let customer = document.getElementById('customerSelect').value;
//    let poolTable = document.getElementById('poolTableSelect').value;
//    let startDate = document.getElementById('start').value;
//    let endDate = document.getElementById('end').value;

//    fetch('http://localhost:7332/booking', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({
//            customerId: customer,
//            tableId: poolTable,
//            startDate: startDate,
//            endDate: endDate
//        })
//    })
//        .then(data => {
//            console.log(data);
//            displayBookings();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });
//}
//async function removeBooking(id) {
//    await fetch('http://localhost:7332/booking/' + id, {
//        method: 'DELETE',
//        headers: { 'Content-Type': 'application/json' },
//        body: null
//    })
//        .then(data => {
//            console.log(data);
//            displayBookings();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });
//}
//function showUpdateBooking(id, start, end, customerId, tableId) {
//    document.getElementById('updateBooking').style.display = 'flex';
//    document.getElementById('startUpdate').value = start;
//    document.getElementById('endUpdate').value = end;
//    document.getElementById('customerSelectUpdate').value = customerId;
//    document.getElementById('poolTableSelectUpdate').value = tableId;
//    bookingIdUpdate = id;
//}
//function UpdateBooking() {
//    let startDate = document.getElementById('startUpdate').value;
//    let endDate = document.getElementById('endUpdate').value;
//    let selectedCustomerId = document.getElementById('customerSelectUpdate').value;
//    let selectedTableId = document.getElementById('poolTableSelectUpdate').value;

//    fetch('http://localhost:7332/booking', {
//        method: 'PUT',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({
//            bookingId: bookingIdUpdate,
//            startDate: startDate,
//            endDate: endDate,
//            customerId: selectedCustomerId,
//            tableId: selectedTableId
//        })
//    })
//        .then(data => {
//            console.log(data);
//            displayBookings();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });

//    document.getElementById('updateBooking').style.display = 'none';
//}
//function formatDate(date) {
//    let d = new Date(date),
//        month = '' + (d.getMonth() + 1),
//        day = '' + d.getDate(),
//        year = d.getFullYear(),
//        hour = '' + d.getHours(),
//        minute = '' + d.getMinutes();

//    if (month.length < 2)
//        month = '0' + month;
//    if (day.length < 2)
//        day = '0' + day;
//    if (hour.length < 2)
//        hour = '0' + hour;
//    if (minute.length < 2)
//        minute = '0' + minute;

//    return [year, month, day].join('.') + ' ' + [hour, minute].join(':');
//}
////#endregion

////PoolTables
////#region PoolTables
//let poolTableIdUpdate = 0;
//function displayPoolTables() {
//    document.getElementById('bookingwindow').style.display = 'none';
//    document.getElementById('pooltablewindow').style.display = 'flex';
//    document.getElementById('customerwindow').style.display = 'none';
//    document.getElementById('updateCustomer').style.display = 'none';
//    document.getElementById('updateBooking').style.display = 'none';
//    document.getElementById('updatePoolTable').style.display = 'none';

//    return getPoolTables().then(() => {

//        document.getElementById('pooltables').innerHTML = "";
//        pooltables.forEach(t => {
//            document.getElementById('pooltables').innerHTML +=
//                `<tr><td><input type="radio" name="selectPoolTableRadio" onclick='showUpdatePoolTable("${t.tableId}","${t.t_kind}")'></input></td>` +
//                "</td><td>" + t.tableId +
//                "</td><td>" + t.t_kind +
//                `</td><td><button type="button" onclick='removePoolTable(${t.tableId})'>Delete</button></td></tr>`;;
//        })
//    });
//}
//function addPoolTable() {

//    fetch('http://localhost:7332/pooltable', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({
//            t_kind: "Pool"
//        })
//    })
//        .then(data => {
//            console.log(data);
//            displayPoolTables();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });
//}
//function addSnookerTable() {

//    fetch('http://localhost:7332/pooltable', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({
//            t_kind: "Snooker"
//        })
//    })
//        .then(data => {
//            console.log(data);
//            displayPoolTables();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });
//}
//async function removePoolTable(id) {
//    await fetch('http://localhost:7332/pooltable/' + id, {
//        method: 'DELETE',
//        headers: { 'Content-Type': 'application/json' },
//        body: null
//    })
//        .then(data => {
//            console.log(data);
//            displayPoolTables();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });
//}
//function showUpdatePoolTable(id, type) {
//    document.getElementById('updatePoolTable').style.display = 'flex';
//    document.getElementById('typeUpdate').value = type;
//    poolTableIdUpdate = id;
//}
//function updatePoolTable() {
//    let type = document.getElementById('typeUpdate').value;

//    fetch('http://localhost:7332/pooltable', {
//        method: 'PUT',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({
//            tableId: poolTableIdUpdate,
//            t_kind: type
//        })
//    })
//        .then(data => {
//            console.log(data);
//            return getPoolTables();
//        })
//        .then(() => {
//            displayPoolTables();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });

//    document.getElementById('updatePoolTable').style.display = 'none';
//}
////#endregion