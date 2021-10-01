public class MyLinkedList {
    int _size;
    Node _head, _tail;
    public MyLinkedList() {
        _size = 0;
        _head = _tail = null;
    }
    // 0-indexed
    public int Get(int index) {
        if (index < 0 || index >= _size || _head == null) return -1;
        var ptr = _head;
        while (--index >= 0) ptr = ptr.next;
        return ptr.val;
    }
    
    public void AddAtHead(int val) {
        _head = new Node (val, _head);
        if (_size == 0) _tail = _head;
        _size++;
    }
    
    public void AddAtTail(int val) {
        var t = new Node(val);
        if (_size == 0) _head = t;
        else _tail.next = t;
        _tail = t;
        _size++;
    }
    
    public void AddAtIndex(int index, int val) {
        if (index < 0 || index > _size) return;
        if (index == 0) { AddAtHead(val); return; }
        if (index == _size) { AddAtTail(val); return; }
        var ptr = _head;
        for (int i = 0; i < index - 1; i++) ptr = ptr.next;
        ptr.next = new Node(val, ptr.next);
        _size++;
    }
    
    public void DeleteAtIndex(int index) {
        if (index < 0 || index >= _size) return;
        var ptr = _head;
        for (int i = 0; i < index - 1; i++) ptr = ptr.next;
        if (index == 0) _head = ptr.next;
        else { 
            ptr.next = ptr.next.next;
            if (index == _size - 1) _tail = ptr;
        }
        _size--;
    }
}
public class Node {
    public int val;
    public Node next;
    public Node (int v, Node nx = null) { val = v; next = nx; }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
