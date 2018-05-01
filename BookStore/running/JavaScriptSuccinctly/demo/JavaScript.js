console.log("start working..");

var myObject = {}; 

myObject.muFunction = function () { };
myObject.myArray = [];
myObject.myString = "mystringValue";
myObject.muNumber = 12; 
myObject.myDate = new Date();
myObject.myRegExp = /a/;
myObject.myNull = null;
myObject.myUndefined = undefined;
myObject.myObject = {};
myObject.myMath_PI = Math.PI;
myObject.myError = new Error('Darn!');


console.log(myObject.myFunction, myObject.myArray, myObject.myString,
    myObject.myNumber, myObject.myDate, myObject.myRegExp, myObject.myNull,
    myObject.myNull, myObject.myUndefined, myObject.myObject, myObject.myMath_PI,
    myObject.myError);

console.log(myObject);
console.log("...sep.....");
console.log(myObject.myDate);

console.log("-----------sep------------");

var object1 = {
    object1_1: {
        object1_1_1: {foo:'bar'},
        object1_1_2: {}
    },
    object1_2: {
        object1_2_1: {},
        object1_2_2: {}
    }
};

console.log(object1.object1_1.object1_1_1.foo);

//----------------------how To access Object Values ---------------------------------------------

var cody = new Object();

cody.living = true;
cody.age = 12; 
cody.gender = 'male';
cody.getGender = function () { return this.gender };


//----this is another way to access data  :

cody['living'] = true;
cody['age'] = 33;
cody['getGenderNormal'] = function () { return "Im another Function "; }; 

console.log("this is GetGender output");
console.log(cody.getGender);
console.log("this is the output of GetGenderNormal Function");
console.log(cody.getGenderNormal);

//--------------deleting element from object ------------------------------

var foo = { bar: 'bar' };

delete foo.bar; 

console.log("this is the outpur after delete for bar"); 

console.log(foo); 

//--------------------------------------------------------------------


















