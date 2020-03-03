
$(document).ready(function () {
    var currentIndex = 0,
     items = $('.slider div'),
      itemsimg = $('.slider img'),
     itemAmt = items.length;

    function cycleItems() {
        var item = $('.slider div').eq(currentIndex);
        items.hide();
        item.css('display', 'inline-block');
        itemsimg.css('width', '100%');
    }

    var autoSlide = setInterval(function () {
        currentIndex += 1;
        if (currentIndex > itemAmt - 1) {
            currentIndex = 0;
        }
        cycleItems();
    }, 5000);

    $('.next').click(function () {
        //   alert(1);
        clearInterval(autoSlide);
        currentIndex += 1;
        if (currentIndex > itemAmt - 1) {
            currentIndex = 0;
        }
        cycleItems();
    });

    $('.prev').click(function () {
        clearInterval(autoSlide);
        currentIndex -= 1;
        if (currentIndex < 0) {
            currentIndex = itemAmt - 1;
        }
        cycleItems();
    });
});

