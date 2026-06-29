package main

import (
    "fmt"
    "net/http"
)

func main() {
    http.HandleFunc("/health", func(w http.ResponseWriter, _ *http.Request) {
        fmt.Fprintln(w, "Ark licensing service healthy")
    })

    fmt.Println("Ark licensing service listening on :8080")
    _ = http.ListenAndServe(":8080", nil)
}
