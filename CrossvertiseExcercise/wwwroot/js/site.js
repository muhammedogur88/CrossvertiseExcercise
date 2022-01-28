
$(function () {
    console.log("Page is ready");
    var month;
    document.querySelectorAll("main nav a").forEach(e => {
        e.addEventListener("click", (el) => {
            el.preventDefault();
            el.stopPropagation();
            month = Number(el.target.getAttribute("data-number"));
            console.log(month);

            $.ajax({
                type: "POST",
                url: 'Calendar/ShowAppointmentByMonth',
                data: { month: month },
                success: function (data) {
                    console.log(data);
                    $("#appointmentData").html(data)
                },
                error: function (req, status, error) {
                    console.log(error);
                }
            })
        });
    });

    $("main nav a").click(function () {
        $("main nav a").removeClass("active");
        $(this).addClass("active");
    });

    $("#navbar").click(function () {
        $("#navbar").removeClass("active");
        $(this).addClass("active");
    });

    $(document).on("click", "#appointmentData ul li a", function (el) {
        el.preventDefault();
        el.stopPropagation();
            asd($(this).data("item-id"));
    });

    function asd(id) {
        $.ajax({
            type: "POST",
            url: 'Calendar/ShowAppointmentDetail',
            data: { id: id },
            success: function (data) {
                console.log(data);
                $("#appointmentData").append(data)
            },
            error: function (req, status, error) {
                console.log(error);
            }
        })
    }



});

