$(document).ready(function () {
    $(".delete-task").click(function () {
        let id = event.target.getAttribute("data-id");
        if (!confirm("Do you want to delele current row?")) {
            return;
        }
        let row = $(this).closest("tr");
        $.ajax({
            type: "POST",
            url: "/Home/DeleteTask",
            data: { StrId: id },
            dataType: "text",
            success:
                function (response) {
                    if (response === 'OK') {
                        row.remove();
                    }                    
                }
        })
    })

    $(".add-edit").click(function () {
        let id = event.target.getAttribute("data-id");
        $.ajax({
            type: "POST",
            url: "/Home/GetTaskById",
            data: { StrId: id },
            dataType: "JSON",
            success:
                function (response) {
                    $("#description").html(response.description);
                    $("#expected-date").html(response.expectedDate);
                }
        })
        $("#addEditModal").modal("show");
    })
})