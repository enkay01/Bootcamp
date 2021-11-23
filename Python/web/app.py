from flask import Flask, request
from flask.templating import render_template

file = open("web\\resources\\films.csv", "r").readlines()
films = []
for line in file:
    string = line.strip().split(",")
    films.append({"title" : string[0], "stars" : string[1]})
print(films)

app = Flask(__name__) 
 
@app.route('/hello') 
def hello_world(): 
 return 'Hello World!'
@app.route('/films/list')
def get_books():
    return render_template("film list.html", films=films)
@app.route('/films/list/filter')
def get_a_book():
    rating = request.values.get("stars", "")
    out = [{"title": "film", "stars": "stars"}]
    for f in films:
        if f['stars'] == rating:
            out.append(f)
    return render_template("film list.html", films=out)

if __name__ == "__main__":
    app.run()