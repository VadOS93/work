var myFunc = function() {
    var array = [];
    return function(x) { 
        if (x !== undefined) {
            array.push(x);
        }
        else {
            array = [];
        }
        return array;
    }
}
var arrayFunc = myFunc();
arrayFunc('sddsf');
arrayFunc(34);
arrayFunc();
arrayFunc(34);