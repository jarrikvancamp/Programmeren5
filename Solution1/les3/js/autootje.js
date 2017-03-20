// declare the global variables
var timer; // reference to window.setInterval timer
var car; // reference to old car image
var banner; // reference to Xrox Car Co banner image
var carLeft;
var isCarSwapped = false;

var startAnimation = function() {
    window.status = 'Welkom op inantwerpen.com';
    car = document.getElementById('car');
    carLeft = 0;
    banner = document.getElementById('banner');
    // start de interval timer
    timer = window.setInterval(moveImages, 10);
}

var moveImages = function() {
    carLeft += 2;
    car.style.left = carLeft + 'px';
    banner.style.left = (carLeft - 370) + 'px';

    // als het autootje het einde van het scherm bereikt heeft
    // wordt het onzichtbaar gemaakt en de banner zichtbaar
    if (carLeft >= window.innerWidth) {
        window.clearInterval(timer); // so stop timer
        car.style.visibility = 'hidden'; // and hide it
        // display the slogan image
        document.getElementById('force').style.visibility = 'visible';
    }
    

        if (!isCarSwapped) {
            // swap to the second car image (no towrope)
            car.src = document.getElementById('car2').src;
            isCarSwapped = true;
    }


}
