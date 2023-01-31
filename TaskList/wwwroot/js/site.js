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
            data: { deleteId: id },
            dataType: "text",
            success: function (response) {
                if (response === 'OK') {
                    row.remove();
                }                    
            }
        })
    })

    $(".add-edit").click(function () {
        let id = event.target.getAttribute("data-id");
        let description = event.target.getAttribute("data-description");
        let date = event.target.getAttribute("data-expected-date");
        $("#addEditModal").modal("show");
    })

    $(".edit-task").click(function () {
        
    })
})