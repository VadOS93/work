function count() { var res = 0; return function(x) { res += x; return res; } };
var counter = count();
counter(5);
counter(25);
counter(285);