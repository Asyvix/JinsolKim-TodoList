using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoService
    {
        private TodoContext _todoContext;
        public ToDoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        public delegate void ToDoListHandler(Todo todo);//델리게이트를 이용하여 메시지를 전달할 통로를 만든다.
        public static event ToDoListHandler Created; 
        public static event ToDoListHandler Updated;

        public static event ToDoListHandler Deleted;
        public List<Todo> All()
        {
            return _todoContext.Todos.ToList();
        }
        public void Create(Todo todo)//생성, 메서드
        {
            _todoContext.Todos.Add(todo); //데이터베이스에 쓸 데이터를 준비한다.
            _todoContext.SaveChanges(); //실제로 데이터를 데이터베이스에 작성한다.
            Created?.Invoke(todo);//메시지가 널값일 경우 오류가 발생함으로 챗 딜리게이트를 실행할 때 널값의 경우도 포함시켜준다. 

        }

        public void Delete(Todo todo)//삭제, 메서드
        {
            _todoContext.Todos.Remove(todo);
            _todoContext.SaveChanges();
            Deleted?.Invoke(todo);//메시지가 널값일 경우 오류가 발생함으로 챗 딜리게이트를 실행할 때 널값의 경우도 포함시켜준다. 

        }

        public void Update(Todo todo)//업데이트, 메서드
        {
            _todoContext.Todos.Update(todo);
            _todoContext.SaveChanges();
            Updated?.Invoke(todo);//메시지가 널값일 경우 오류가 발생함으로 챗 딜리게이트를 실행할 때 널값의 경우도 포함시켜준다. 

        }

    }
}
