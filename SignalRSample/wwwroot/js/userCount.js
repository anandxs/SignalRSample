let connectionUserCount = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/userCount")
    .build();

connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
});

function windowLoadedOnClient() {
    connectionUserCount.invoke("WindowLoaded", "Anand");
}

function fulfilled() {
    windowLoadedOnClient();
}

function rejected() {
    console.log("Something went wrong.");
}

connectionUserCount.start().then(fulfilled, rejected)