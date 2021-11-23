from flask import Flask
from flask.templating import render_template 

books = [ 
 { 'id': 1, 'title': 'Clean Code', 'authors': 'Robert C. Martin' }, 
 { 'id': 2, 'title': 'The DevOps Handbook', 'authors': 'Gene Kim, Jez Humble, Patrick Debois, John Willis' }, 
 { 'id': 3, 'title': 'The Phoenix Project', 'authors': 'Gene Kim, Kevin Behr, George Spafford' }] 


app = Flask(__name__) 
 
@app.route('/hello') 
def hello_world(): 
 return 'Hello World!'
@app.route('/books')
def get_books():
    return render_template('book list.html', books=books)

if __name__ == "__main__":
    app.run()