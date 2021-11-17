public class ParkingSystem {
    int[] carCnt;
    public ParkingSystem(int big, int medium, int small) {
        carCnt = new int[]{big, medium, small};
    }
    
    public bool AddCar(int carType) {
        return carCnt[carType - 1]-- > 0;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */
