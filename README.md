# USS-Library
It's Library of USS Language
# Examples
%s uss example.uss = {

  game_name = "github.text",
  
  object = {
  
    name = "Object Door",
    
    id = 0,
    
    png = "C:\Users\Me\Desktop\door.png",
    
    script = "C:\Users\Me\Desktop\door.ussp",
    
    size = {
    
      height = 2,
      
      length = 1
      
    }
    
  },
  
  screen = {
  
    height = 100,
    
    length = 100
    
  }
  
} %f
# How To Create
%s [name].uss = {

  [name] = [value]
  
  ...
  
}

//

[name] = [(numbers & )letters]

[name] != [symbols]

//

[value] = [" & letters &"], [nubers]

[value] != [letters], [symbols]

//

extra : 
  [value] = { ... }
