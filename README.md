# DemoActorsMatchApp

This is a demo app of finding matched filmings of any two actors. <br>

The data is fetched from https://imdb-api.com/api/#Search-header. In order to test the app, do these steps:<br>
1) Clone the project<br>
2) Get API key from https://imdb-api.com/.<br>

After that, set your API key into appsettings.json:<br>
```
"ImdbClientOptions": {
    "ApiKey": "YourAPIKey",
    "BaseUrl": "https://imdb-api.com/en/API/"
  }
```

Finally, in the project folder run this command:
```
docker-compose up -d
```

App will be running at port ``8081`` and API will be available at this url: http://localhost:8081/swagger/index.html
