window.menu = (function(){

//Creates the menu based off the request from the web API
function PopulateMenu(callback) {
    var c = console
    var MenuAPIUrl = 'http://localhost/MenuWebAPI/api/Menu/';
    var xhr = new XMLHttpRequest()

    var promise = new Promise(function(resolve, reject) {
        var xhr = new XMLHttpRequest()
        xhr.onreadystatechange = function() {
            if (xhr.readyState == 4)
            {
                if (xhr.status > 199 && xhr.status < 300) 
                    {
                        resolve(JSON.parse(xhr.responseText))
                    }
                else
                    {
                        reject(Error(xhr.status + " " + xhr.statusText))
                    }
            }

            var data = xhr.responseText;
            
        }
    

    xhr.open("GET", MenuAPIUrl, true);
    xhr.send();

    })

    promise.then(function(data){
            var obj = JSON.parse(data);
            callback(obj);
    })
}
    return{
        PopulateMenu: PopulateMenu
    };
})();