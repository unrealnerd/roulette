# Roulette API

This API application provides a way to fetch a N random items from any custom domain entity we provide the application using mongodb.

<img src="img/roulette.jpg"  width="800" >

The application uses Mongodb as repository and [$sample aggreation](https://docs.mongodb.com/manual/reference/operator/aggregation/sample/index.html) and returns N Random Phrases.

## Usage:

You can run this application using VSCode `F5` or just run `docker-compose up`

### Sample Request

`curl --request GET --url http://localhost:5000/api/phrases/1`
