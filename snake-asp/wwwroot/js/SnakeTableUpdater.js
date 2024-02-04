class SnakeTableUpdater {
    #_intervalId;
    #_timeout;
    #_rootNodeId;

    constructor(timeout, rootNodeId) {
        this.#_timeout = timeout;
        this.#_rootNodeId =rootNodeId;
    }

    #Updater(_this) {
        $(`#`+_this.#_rootNodeId).load("Api/GetFiend");
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