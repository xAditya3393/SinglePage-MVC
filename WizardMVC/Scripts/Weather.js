$(document).ready(function () {

    $('#submitWeather').click(function () {

        var city = $("#city").val();

        if (city != '') {

            $.ajax({

                url: "http://api.openweathermap.org/data/2.5/weather?q=" + city +
                    "&appid=648f502f93b2bd78a179c68dd05b4bb9",
                type: "GET",
                dataType: "jsonp",
                success: function (data) {

                    var widget = show(data);
                    
                    $("#show").html(widget);
                    $("#city").val('');
                }
            });

        }
        else {

            $("#error").html("Field Cannot be Empty");
        }

    });

});


function show(data) {

    return "<h3 style='font-size:40px; font-weight: bold;' class='text-center'>Current Weather for " +
        data.name +", "+ data.sys.country +"</h3>"+

            "<h3 style='padding-left:40px;'><strong>Weather</strong>: " + data.weather[0].main + "</h3>" +
            "<h3 style='padding-left:40px;'><strong>Description</strong>: <img src='http://openweathermap.org/img/w/" +
              data.weather[0].icon + ".png'> " + data.weather[0].description + "</h3>" +
    "<h3 style='padding-left:40px;'><strong>Temperature</strong>: " + data.main.temp + "&deg;C</h3>" +
    "<h3 style='padding-left:40px;'><strong>Pressure</strong>: " + data.main.pressure + " hPa</h3>" +
    "<h3 style='padding-left:40px;'><strong>Humidity</strong>: " + data.main.humidity + "%</h3>" +
    "<h3 style='padding-left:40px;'><strong>Min. Temperature</strong>: " + data.main.temp_min + "&deg;C</h3>" +
    "<h3 style='padding-left:40px;'><strong>Max. Temperature</strong>: " + data.main.temp_max + "&deg;C</h3>" +
    "<h3 style='padding-left:40px;'><strong>Max. Temperature</strong>: " + data.wind.speed + " m/s</h3>" +
    "<h3 style='padding-left:40px;'><strong>Max. Temperature</strong>: " + data.wind.deg + "&deg;C</h3>" 
                
}