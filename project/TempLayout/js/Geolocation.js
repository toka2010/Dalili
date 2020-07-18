var x = document.getElementById("map");

function getLocation() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showPosition, showError);
  } else { 
    x.innerHTML = "Geolocation is not supported by this browser.";
  }
}

function showPosition(position) {

  x.innerHTML = "<table border='2px' width='190px'> <tr><td>Latitude</td> " +"<td>"+ position.coords.latitude + 
  "</td> </tr><tr><td>Longitude</td> " + "<td>"+ position.coords.longitude + "</td></tr><tr><td>Accurancy </td>" + "<td>"+ position.coords.accuracy+
  "</td></tr><tr><td>  Date  "+ "<td>"+new Date().toISOString()+"</td></tr> </table>";
}

function showError(error) {
  switch(error.code) {
    case error.PERMISSION_DENIED:
      x.innerHTML = "User denied the request for Geolocation."
      break;
    case error.POSITION_UNAVAILABLE:
      x.innerHTML = "Location information is unavailable."
      break;
    case error.TIMEOUT:
      x.innerHTML = "The request to get user location timed out."
      break;
    case error.UNKNOWN_ERROR:
      x.innerHTML = "An unknown error occurred."
      break;
  }
}
var map = document.querySelector('#map');
        var displayBtn = document.querySelector('#displayBtn')
        displayBtn.addEventListener('click', function () {
            if (navigator.geolocation) {
                //b support geolocation
                navigator.geolocation.getCurrentPosition(initMap, error)
            } else {
                map.innerText = "your browser doesn't support geolocation"
            }
        })

        function initMap(position) {
             accur = position.coords.accuracy;
  var myLatLng = {lat: 30.6206344, lng: 32.2924435};

  var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 20,
    center: myLatLng
  });

  var marker = new google.maps.Marker({
    position: myLatLng,
    map: map,
    title: 'Hello World!'
  });
}
        

        function error(erroObj) {
            var message = ""
            switch(erroObj.code){
                case 1:{
                    message = "allow me to get your location"
                }
                break;
                case 2:{
                    message = "unable to get location"
                }
                break;
                case 3:{
                    message = "check your connection an try again" 
                }
                break;
                default:{
                    message="unkown error, try again."
                }
            }
            map.innerText = message;
        }
        
        

//var datee=new Date().toISOString();
//console.log(datee);
 //var accur = position.coords.accuracy;
 //console.log( accur);

