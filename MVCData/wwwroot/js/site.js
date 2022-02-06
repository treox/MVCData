function getPeople() {
    $.get("Ajax/PeopleList", function (data, status) {

        document.getElementById("ajaxPeopleList").innerHTML = data;
    });
}

function getPersonById() {
    let idField = document.getElementById("id-field");

    $.post("Ajax/PeopleWithId",
        {
            id: idField.value
        },
        function (idData, idStatus) {
            document.getElementById("ajaxPeopleList").innerHTML = idData;
        });
}

function deletePersonById() {
    let idField = document.getElementById("id-field");

    let xhrStatus = "";

        $.post("Ajax/DeletePeopleWithId",
            {
                id: idField.value
            },
            function (deleteData, deleteStatus, xhr) {

                xhrStatus = xhr.status;

                document.getElementById("ajaxPeopleList").innerHTML = "Personen raderades! " + deleteStatus + " Status: " + xhr.status;

            });

    if (xhrStatus == "")
        document.getElementById("ajaxPeopleList").innerHTML = "Fel: Personen kunde inte hittas!";

}