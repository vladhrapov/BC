export const authorization = (state = [], action) => {
  switch (action.type) {
    case "LOGGED_IN":
      console.log("LOGGED_IN: ", [
        ...state,
        action.payload
      ]);
      return [
        ...state,
        action.payload
      ];
    case "LOGGED_OUT":
      console.log("LOGGED_OUT: ", [
        ...state,
        action.payload
      ]);
      return [
        ...state,
        action.payload
      ];

    default:
      return state;
  }
}
