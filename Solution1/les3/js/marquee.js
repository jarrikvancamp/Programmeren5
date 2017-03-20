var scrollDelay = 2000; //Specify initial delay before marquee starts to scroll on page (2000=2 seconds)
var marqueeSpeed = 1; //Specify marquee scroll speed (larger is faster 1-10)
var timer;

var scrollArea;
var marquee;
var scrollPosition = 0;

var scrolling = function() {
  if (scrollPosition + scrollArea.offsetHeight <= 0) {
    scrollPosition = marquee.offsetHeight;
  }
  else {
    scrollPosition = scrollPosition - marqueeSpeed;

  }
  scrollArea.style.top = scrollPosition + "px";
}


var startScrolling = function() {
  timer = setInterval(scrolling, 30);
}

var initializeMarquee = function() {
  scrollArea = document.getElementById("scroll-area");
  scrollArea.style.top = 0;
  marquee = document.getElementById("marquee");
  setTimeout(startScrolling, scrollDelay);
}

var pauseMarquee = function() {
  if (marqueeSpeed > 0) {
    marqueeSpeed = 0;
  }
  else {
    marqueeSpeed = 1;
  }
}

var speedUpMarquee = function() {
  if (marqueeSpeed <= 3) {
    marqueeSpeed++;
    // alert(marqueeSpeed);
  }

}

var slowDownMarquee = function() {
  // alert(marqueeSpeed);
  if (marqueeSpeed > 1) {
    marqueeSpeed--;
  }
}


window.onload = initializeMarquee;
