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

    $(".edit-task").click(function () {
        
    })
})