class SnakeStatusGetter {
    #_intervalId;
    #_timeout;

    constructor(timeout) {
        this.#_timeout = timeout;
    }

    #Updater(_this) {
       // $(`#`+_this.#_rootNodeId).load("Api/GetStatus");
        $.ajax("Api/snakeStatusDataModel", {})
            .done(function (responseData) {
                console.log(responseData)
                if (responseData.isSnakeDead === false) {
                    setTimeout(function ()
                    { alert("Игра окончена.") }, _this.#_timeout)
                    
                    _this.Stop()
                }
            })
    }

    Start() {
        this.Stop()
        this.#_intervalId=setInterval(this.#Updater, this.#_timeout, this);
    }

    Stop() {
        if (this.#_intervalId) {
        clearInterval(this.#_intervalId);
        }
    }
}